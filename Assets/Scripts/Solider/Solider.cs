using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Solider : MonoBehaviour
{
    public bool selected;
    public int level;

    public Transform Enemy;
    public NavMeshAgent agent;

    public Vector3 screenPosition;
    public Vector3 worldPosition;
    public LayerMask layersToHit;

    public Collider trackingArea;
    Vector3 position;

    private void Start()
    {
        position = transform.position;
    }

    private void OnMouseDown()
    {
        selected = true;
    }
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            selected = false;
            position = transform.position;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            AttackTime();
        }
        screenPosition = Input.mousePosition;

        Ray ray = Camera.main.ScreenPointToRay(screenPosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && hit.collider == trackingArea)
        {
            worldPosition = hit.point;
        }

        if (selected == true)
        {
            transform.position = new Vector3(
                Mathf.Round(worldPosition.x),
                1,
                Mathf.Round(worldPosition.z)
                );
        }
    }
    public void AttackTime()
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
                    Destroy(other.gameObject);
                    transform.localScale = new Vector3(
                        transform.localScale.x+ 0.05f,
                        transform.localScale.y+ 0.05f,
                        transform.localScale.z+ 0.05f
                        );
                }
                else
                {
                    transform.position = position;
                }
            }
        }
    }
}