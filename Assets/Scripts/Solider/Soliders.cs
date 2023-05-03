using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Soliders : MonoBehaviour
{
    public int level;

    [Header("Attack")]
    public float OverlapRadius = 10.0f;

    public Transform nearestEnemy;
    private int enemyLayer;

    public abstract void Attack();

    private void Start()
    {
        enemyLayer = LayerMask.NameToLayer("Enemy");
    }

    private void Update()
    {
        if (nearestEnemy != null)
        {
            nearestEnemy.GetComponent<MeshRenderer>().material.color = Color.green;
        }

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, OverlapRadius, 1 << enemyLayer);
        float minimumDistance = Mathf.Infinity;
        foreach (Collider collider in hitColliders)
        {
            float distance = Vector3.Distance(transform.position, collider.transform.position);
            if (distance < minimumDistance)
            {
                minimumDistance = distance;
                nearestEnemy = collider.transform;
            }
        }
        if (nearestEnemy != null)
        {
            nearestEnemy.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        else
        {
            Debug.Log("There is no enemy in the given radius");
        }
    }
}
