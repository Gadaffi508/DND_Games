using System.Collections;
using UnityEngine;

public class EnemyHealth : Health
{
    public bool IsDead;

    IEnumerator Start()
    {
        manager = FindObjectOfType<GameManager>();
        _health += GameManager.Instance.level * 2;
        yield return new WaitForSeconds(1);
        manager.AddEnemyToList(gameObject);
    }

    public override void Takedamage(int damage)
    {
        UpdateHealthBar();

        _health -= damage;

        if (_health <= 0)
        {
            GameManager.Instance.gold += 50;
            GameManager.Instance._earnedGold += 50;
            Die();
            IsDead = true;
        }
    }
    public override void Die()
    {
        Instantiate(DieParticle, transform.position, Quaternion.identity);
        manager.EnemyDestroyed(gameObject);
        Destroy(gameObject);
    }
}
