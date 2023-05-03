using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : Soliders
{
    public float _speed;
    bool _attack = false;

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
            Transform enemy = nearestEnemy.GetComponent<Transform>();

            transform.position = Vector3.MoveTowards(transform.position, enemy.position, _speed * Time.deltaTime);
            Vector3 distances = transform.position - enemy.position;
            if (distances.z < 0.5f && distances.x < 0.5f)
            {
                _attack = false;
            }
        }
    }
}
