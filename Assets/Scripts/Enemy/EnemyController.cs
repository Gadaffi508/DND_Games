using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Attack")]
    public float OverlapRadius = 10.0f;

    public Transform nearestPlayer;
    private int playerLayer;
    public float _speed;

    [Space]
    [Header("Controller")]
    public Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, OverlapRadius, 1 << playerLayer);
        float minimumDistance = Mathf.Infinity;
        foreach (Collider collider in hitColliders)
        {
            float distance = Vector3.Distance(transform.position, collider.transform.position);
            if (distance < minimumDistance)
            {
                minimumDistance = distance;
                nearestPlayer = collider.transform;
            }
        }
        if (nearestPlayer != null)
        {
            Transform Player = nearestPlayer.GetComponent<Transform>();

            Vector3 direction = Player.position - transform.position;
            direction.y = 0;
            transform.LookAt(transform.position + direction);

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("Attack");
        }
    }
}
