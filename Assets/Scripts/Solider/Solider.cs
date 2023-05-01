using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Solider : MovementMousePosition
{
    public override void AttackTime()
    {
        agent.destination = Enemy.position;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            agent.destination = transform.position;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            if (selected == true)
            {
                int levelControl = other.gameObject.GetComponent<Solider>().level;
                if (level == levelControl)
                {
                    level += 1;
                    Destroy(other.gameObject);
                    transform.localScale = new Vector3(
                        transform.localScale.x + 0.05f,
                        transform.localScale.y + 0.05f,
                        transform.localScale.z + 0.05f
                        );
                }
                else
                {
                    Debug.Log("oolmadý");
                    Vector3 _position = other.gameObject.GetComponent<Solider>().position;
                    transform.position = _position;
                }
            }
        }
    }
}