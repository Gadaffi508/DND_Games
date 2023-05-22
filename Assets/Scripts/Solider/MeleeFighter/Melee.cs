using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Melee : Soliders
{
    public float _speed;
    public bool _attack = false;
    public float movementSpeedThreshold = 0.1f;

    public int attackDamage = 20;

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
            AttackFind();

        }
        else
        {
            anim.SetBool("IsWalk", _attack);
        }

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            _speed = 0;
            if (other.gameObject.GetComponent<EnemyHealth>()._health < 0)
            {
                _attack = true;
                AttackFind();
                StopCoroutine(AttackRetry());
            }
            if (other.gameObject.GetComponent<EnemyHealth>()._health > 0)
            {
                _attack = false;
                anim.SetTrigger("Attack");
                StartCoroutine(AttackRetry());
            }
        }
    }
    IEnumerator AttackRetry()
    {
        yield return new WaitForSeconds(1);
        anim.SetTrigger("Attack");
    }
    public void Damage()
    {
        nearestEnemy.GetComponent<EnemyHealth>().Takedamage(attackDamage);
    }
    public void AttackFind()
    {
        if (nearestEnemy != null)
        {
            Collider.isTrigger = false;
            Transform enemy = nearestEnemy.GetComponent<Transform>();
            Vector3 enemypos = new Vector3(enemy.position.x, transform.position.y, enemy.position.z);
            transform.position = Vector3.MoveTowards(transform.position, enemypos, _speed * Time.deltaTime);
            anim.SetBool("IsWalk", _attack);

            Vector3 direction = enemy.position - transform.position;
            direction.y = 0;
            transform.LookAt(transform.position + direction);

        }
    }
}
