using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class Melee : Soliders
{
    public float _speed;
    public bool _attack = false;

    public int attackDamage = 20;
    private float distance;

    public override void Attack()
    {
        if (nearestEnemy != null)
        {
            _attack = true;
        }
    }

    private void FixedUpdate()
    {
        if (_attack == true)
        {
            if (nearestEnemy != null)
            {
                Transform enemy = nearestEnemy.GetComponent<Transform>();
                distance = Vector3.Distance(transform.position, enemy.position);
                if (distance < 0.25)
                {
                    _speed = 0;
                    anim.SetBool("IsWalk", false);
                    anim.SetBool("Attack", true);
                }
                else
                {
                    AttackFindEnemy();
                }
            }
            if (nearestEnemy == null)
            {
                anim.SetBool("Attack", false);
                anim.SetBool("IsWalk", false);
            }
        }

    }
    public void AttackFindEnemy()
    {
        anim.SetBool("Attack", false);
        anim.SetBool("IsWalk", true);
        _speed = 1.5f;
        Collider.isTrigger = false;
        Transform enemy = nearestEnemy.GetComponent<Transform>();
        Vector3 enemypos = new Vector3(enemy.position.x, transform.position.y, enemy.position.z);
        transform.position = Vector3.MoveTowards(transform.position, enemypos, _speed * Time.deltaTime);
        anim.SetBool("IsWalk", _attack);

        Vector3 direction = enemy.position - transform.position;
        direction.y = 0;
        transform.LookAt(transform.position + direction);
    }
    public void Damage()
    {
        if (nearestEnemy != null)
        {
            nearestEnemy.GetComponent<EnemyHealth>().Takedamage(attackDamage);
        }
    }
}
