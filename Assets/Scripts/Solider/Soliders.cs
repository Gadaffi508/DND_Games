using UnityEngine;

public abstract class Soliders : MonoBehaviour
{
    public int level;
    public TextMesh TextLevel;
    public GameObject HealtBG;

    [Header("Attack")]
    public float OverlapRadius = 10.0f;
    public Transform nearestEnemy;
    private int enemyLayer;
    public int random;

    [Space]
    [Header("Controller")]
    public Animator anim;
    public Rigidbody rb;
    public Collider Collider;
    public int gold;

    public abstract void Attack();

    public int m_fighterLevel;
    public int m_WizardLevel;
    public int m_ThiefLevel;

    private void Start()
    {
        enemyLayer = LayerMask.NameToLayer("Enemy");
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        Collider = GetComponent<Collider>();
        HealtBG.SetActive(false);
        random = Random.Range(0, 3);

        FighterSetLevel();
        ThiefSetLevel();
        WizardSetLevel();
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



    void FighterSetLevel()
    {
        if (PlayerPrefs.HasKey("m_fighterLevel"))
        {
            m_fighterLevel = PlayerPrefs.GetInt("m_fighterLevel");
        }
    }

    void ThiefSetLevel()
    {
        if (PlayerPrefs.HasKey("m_ThiefLevel"))
        {
            m_ThiefLevel = PlayerPrefs.GetInt("m_ThiefLevel");
        }
    }

    void WizardSetLevel()
    {
        if (PlayerPrefs.HasKey("m_WizardLevel"))
        {
            m_WizardLevel = PlayerPrefs.GetInt("m_WizardLevel");
        }
    }
}
