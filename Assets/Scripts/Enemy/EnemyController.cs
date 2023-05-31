using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyController : MonoBehaviour
{
    [Header("Attack")]
    public float OverlapRadius = 10.0f;
    bool _attack = false;

    public Transform nearestPlayer;
    private int PlayerLayer;

    [Space]
    [Header("Controller")]
    public Animator anim;
    private float distance;
    public int attackDamage = 15;

    public float rotationSpeed = 5f;

    void Start()
    {
        anim = GetComponent<Animator>();
        PlayerLayer = LayerMask.NameToLayer("Solider");
    }

    private void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, OverlapRadius, 1 << PlayerLayer);
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
    }

    private void FixedUpdate()
    {
        if (nearestPlayer != null)
        {
            Transform Player = nearestPlayer.GetComponent<Transform>();
            distance = Vector3.Distance(transform.position, Player.position);

            transform.rotation = Rotate();

            if (Attackable())
            {
                anim.SetBool("Attack", true);
            }
            else
            {
                AttackFindEnemy();
            }
        }
        else
        {
            anim.SetBool("Attack", false);
        }
    }

    public void AttackFindEnemy()
    {
        anim.SetBool("Attack", false);
        transform.rotation = Rotate();
    }

    public Quaternion Rotate()
    {
        Vector3 direction = PlayerPos() - transform.position;
        direction.y = 0f;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        return Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }

    public void Damage()
    {
        if (nearestPlayer != null)
        {
            nearestPlayer.GetComponent<SoliderHealth>().Takedamage(attackDamage);
        }
    }

    private bool Attackable()
    {
        distance = Vector3.Distance(transform.position, PlayerPos());

        return distance < 0.25f;
    }
    public Vector3 PlayerPos()
    {
        Transform player = nearestPlayer.GetComponent<Transform>();
        Vector3 playerpos = new Vector3(player.position.x, transform.position.y, player.position.z);
        return playerpos;
    }
}
