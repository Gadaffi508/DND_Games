using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    public bool IsDead;

    IEnumerator Start()
    {
        manager = FindObjectOfType<GameManager>();
        yield return new WaitForSeconds(1);
        manager.AddEnemyToList(gameObject);
    }

    public override void Takedamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            GameManager.Instance.gold += 50;
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
