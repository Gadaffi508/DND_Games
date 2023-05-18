using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Melee : Soliders
{
    public float _speed;
    bool _attack = false;
    public float movementSpeedThreshold = 0.1f;
    bool attack = false;

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
                Collider.isTrigger = false;
                Transform enemy = nearestEnemy.GetComponent<Transform>();
                Vector3 enemypos = new Vector3(enemy.position.x, transform.position.y, enemy.position.z);
                transform.position = Vector3.MoveTowards(transform.position, enemypos, _speed * Time.deltaTime);
                anim.SetBool("IsWalk",_attack);

                Vector3 direction = enemy.position - transform.position;
                direction.y = 0;
                transform.LookAt(transform.position + direction);

            }

        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            _speed = 0;
            anim.SetTrigger("Attack");
            _attack = false;

        }
    }
    public void Attacked()
    {
        anim.SetTrigger("Attack");
    }
}
