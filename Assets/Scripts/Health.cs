using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    public int _health;
    public GameObject DieParticle;

    public static Health health;

    private void Awake()
    {
        health = this;
    }

    public abstract void Takedamage(int damage);
    public abstract void Die();
}
