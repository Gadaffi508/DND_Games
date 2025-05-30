using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Attack")]
    public float OverlapRadius = 10.0f;
    public bool _attack = false;
    public float _speed;
    public Transform nearestPlayer;
    private int PlayerLayer;

    [Space]
    [Header("Controller")]
    public Animator anim;
    private float distance;
    public int attackDamage = 15;
    public GameObject HealtBG;
    public float rotationSpeed = 5f;

    [Space]
    [Header("Enemy")]
    [SerializeField] private bool m_isC�ce = false;
    [SerializeField] private bool m_isOrk = false;

    [SerializeField] private int random;

    void Start()
    {
        anim = GetComponent<Animator>();
        PlayerLayer = LayerMask.NameToLayer("Solider");
        HealtBG.SetActive(false);

        anim.speed = m_isC�ce ? 1.6f : 1;
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
        if (_attack)
        {
            if (nearestPlayer != null)
            {
                Transform Player = nearestPlayer.GetComponent<Transform>();
                distance = Vector3.Distance(transform.position, Player.position);

                if (Attackable())
                {
                    _speed = 0;
                    anim.SetFloat("RandomValue", random);
                    anim.SetBool("IsWalk", false);
                    anim.SetBool("Attack", true);
                }
                else
                {
                    _speed = 1;
                    AttackFindEnemy();
                }
            }
            else
            {
                anim.SetBool("Attack", false);
            }
        }
    }

    public void AttackFindEnemy()
    {
        HealtBG.SetActive(true);

        anim.SetBool("Attack", false);
        anim.SetBool("IsWalk", true);

        transform.position = Vector3.MoveTowards(transform.position, PlayerPos(), _speed * Time.deltaTime);

        anim.SetBool("IsWalk", _attack);

        Vector3 direction = PlayerPos() - transform.position;
        direction.y = 0;

        transform.LookAt(transform.position + direction);
    }

    public void Damage()
    {
        if (nearestPlayer != null)
        {
            nearestPlayer.GetComponent<SoliderHealth>().Takedamage(attackDamage + (GameManager.Instance.level * 5));
        }
    }

    private bool Attackable()
    {
        distance = Vector3.Distance(transform.position, PlayerPos());

        return distance < 0.75f;
    }
    public Vector3 PlayerPos()
    {
        Transform player = nearestPlayer.GetComponent<Transform>();
        Vector3 playerpos = new Vector3(player.position.x, transform.position.y, player.position.z);
        return playerpos;
    }

    public void NewRandom()
    {
        random = Random.Range(0, 3);
    }
}
