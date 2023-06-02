using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoliderHealth : Health
{
    Melee solider;

    IEnumerator Start()
    {
        solider = GetComponent<Melee>();
        manager = FindObjectOfType<GameManager>();
        yield return new WaitForSeconds(1);
        manager.AddSoliderToList(gameObject);
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
        manager.SoliderDestroyed(gameObject);
        Instantiate(DieParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
