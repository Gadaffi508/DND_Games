using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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
            if (Attackable())
            {
                anim.SetBool("Attack", true);
            }
            else
            {
                AttackFindEnemy();
            }
        }
    }

    public void AttackFindEnemy()
    {
        anim.SetBool("Attack", false);
        Vector3 direction = PlayerPos() - transform.position;
        direction.y = 0;
        transform.LookAt(transform.position + direction);
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
