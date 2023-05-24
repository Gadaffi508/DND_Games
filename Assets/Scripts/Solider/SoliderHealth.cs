using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoliderHealth : Health
{

    public override void Takedamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Die();
        }
    }
    public override void Die()
    {
        Destroy(gameObject);
    }
}
