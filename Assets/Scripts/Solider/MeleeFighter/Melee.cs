using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Melee : Soliders
{
    public float _speed;
    bool _attack = false;
    private float timeCount = 0.0f;

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
                Vector3 enemypos = new Vector3(enemy.position.x, transform.position.y, enemy.position.z);
                transform.position = Vector3.MoveTowards(transform.position, enemypos, _speed * Time.deltaTime);

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
            Destroy(other.gameObject);
            _attack = true;
        }
    }
}
