using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    public bool IsDead;
    public override void Takedamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Die();
            IsDead = true;
        }
    }
    public override void Die()
    {
        Destroy(gameObject);
    }
}
