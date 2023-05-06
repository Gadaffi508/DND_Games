
using UnityEngine;

public class Magic : Soliders
{
    public float _speed;
    bool _attack = false;

    public override void Attack()
    {
        if (nearestEnemy != null && movementController.lastCell == null)
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
