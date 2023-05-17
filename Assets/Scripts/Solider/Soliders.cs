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

    [Space]
    [Header("Controller")]
    public Animator anim;
    public Rigidbody rb;

    public abstract void Attack();


    private void Start()
    {
        enemyLayer = LayerMask.NameToLayer("Enemy");
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        
    }

    private void Update()
    {

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
    }
}
