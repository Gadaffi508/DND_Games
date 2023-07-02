using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoliderHealth : Health
{
    Melee solider;
    public GameObject levelUpEffect;
    public float LevelTime = 1;

    IEnumerator Start()
    {
        solider = GetComponent<Melee>();
        manager = FindObjectOfType<GameManager>();
        yield return new WaitForSeconds(1);
        manager.AddSoliderToList(gameObject);
    }

    public override void Takedamage(int damage)
    {
        UpdateHealthBar();

        _health = (_health - damage) + (solider.level * 3);

        if (_health <= 0)
        {
            Die();
        }
    }
    public override void Die()
    {
        manager.SoliderDestroyed(gameObject);
        Instantiate(DieParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void levelUp()
    {
        manager.SoliderDestroyed(gameObject);
        GameObject effect = Instantiate(levelUpEffect, transform.position, levelUpEffect.transform.rotation);
        Destroy(gameObject);
        Destroy(effect, LevelTime);
    }
}
