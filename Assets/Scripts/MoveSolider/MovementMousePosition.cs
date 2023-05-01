using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class MovementMousePosition : MonoBehaviour
{
    public bool selected;
    public int level;

    public Transform Enemy;
    public NavMeshAgent agent;

    public Vector3 screenPosition;
    public Vector3 worldPosition;
    public LayerMask layersToHit;

    public Collider trackingArea;
    public Vector3 position;

    private void Start()
    {
        position = transform.position;
    }

    private void OnMouseDown()
    {
        selected = true;
        position = transform.position;
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
    public abstract void AttackTime();

    
}