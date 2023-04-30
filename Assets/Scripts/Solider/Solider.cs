using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Solider : MonoBehaviour
{
    public bool selected;
    public int id;

    public Transform Enemy;
    public NavMeshAgent agent;

    private void OnMouseDown()
    {
        selected = true;
    }
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            selected = false;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            AttackTime();
        }
    }
    public void AttackTime()
    {
        agent.destination = Enemy.position;
    }
}