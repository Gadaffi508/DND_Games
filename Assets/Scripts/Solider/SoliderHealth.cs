using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoliderHealth : Health
{
    Melee solider;

    private void Start()
    {
        solider = GetComponent<Melee>();
    }

    public override void Takedamage(int damage)
    {
        _health -= damage - (solider.level * 3);

        if (_health <= 0)
        {
            Die();
        }
    }
    public override void Die()
    {
        Instantiate(DieParticle,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}
