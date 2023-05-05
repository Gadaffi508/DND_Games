using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            _attack = true;
            Debug.Log(other.gameObject);
        }
    }
}
