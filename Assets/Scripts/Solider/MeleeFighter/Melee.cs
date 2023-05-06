using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : Soliders
{
    public float _speed;
    bool _attack = false;

    public override void Attack()
    {
        for (int i = 0; i < cellController.startingCells.Count; i++)
        {
            var a = cellController.startingCells[i];
            Debug.Log(a.transform.position);
            if (nearestEnemy != null && movementController.lastCell == null && transform.position != a.transform.position)
            {
                _attack = true;
            }
        }


    }

    private void FixedUpdate()
    {
        if (_attack == true)
        {
            if (nearestEnemy != null)
            {
                Transform enemy = nearestEnemy.GetComponent<Transform>();
                transform.position = Vector3.MoveTowards(transform.position, enemy.position, _speed * Time.deltaTime);
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
