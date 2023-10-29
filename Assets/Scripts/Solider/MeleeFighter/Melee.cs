using System.Collections;
using UnityEngine;

public class Melee : Soliders
{
    public float _speed;
    public bool _attack = false;

    public int attackDamage = 20;
    private float distance;

    [SerializeField] private bool İsThief = false;
    [SerializeField] private bool İsWizard = false;
    [SerializeField] private bool isFighter = false;

    [SerializeField] private GameObject FightParticleR;
    [SerializeField] private GameObject FightParticleL;

    public override void Attack()
    {
        if (nearestEnemy != null)
        {
            _attack = true;
            HealtBG.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        if (_attack == true)
        {
            if (nearestEnemy != null)
            {
                Transform enemy = nearestEnemy.GetComponent<Transform>();
                distance = Vector3.Distance(transform.position, enemy.position);

                if (Attackable())
                {
                    _speed = 0;
                    anim.SetFloat("RandomValue", random);
                    anim.SetBool("IsWalk", false);
                    anim.SetBool("Attack", true);
                }
                else
                {
                    AttackFindEnemy();
                }
            }
            if (nearestEnemy == null)
            {
                anim.SetBool("Attack", false);
                anim.SetBool("IsWalk", false);
            }
            TextLevel.text = "";
        }
        else
        {
            TextLevel.text = level.ToString();
        }
    }
    public void AttackFindEnemy()
    {
        anim.SetBool("Attack", false);
        anim.SetBool("IsWalk", true);
        _speed = 1.5f;
        Collider.isTrigger = false;

        transform.position = Vector3.MoveTowards(transform.position, EnemyPos(), _speed * Time.deltaTime);
        anim.SetBool("IsWalk", _attack);

        Vector3 direction = EnemyPos() - transform.position;
        direction.y = 0;
        transform.LookAt(transform.position + direction);
    }
    public void Damage()
    {
        if (nearestEnemy != null)
        {
            nearestEnemy.GetComponent<EnemyHealth>().Takedamage(attackDamage + (level * 10) + (DiceNumberText.diceNumber * 5));
        }

        if (isFighter == true)
        {
            attackDamage = (level * 15) + (attackDamage / 5) + (m_fighterLevel * 10);
        }

        if (İsThief == true)
        {
            GameManager.Instance.gold += 15 + (m_ThiefLevel * 2);
            GameManager.Instance._earnedGold += 15 + (m_ThiefLevel * 2);
        }
        if (İsWizard == true && nearestEnemy != null)
        {
            nearestEnemy.GetComponent<Animator>().speed -= (.2f + (m_WizardLevel/20));
        }
        else if (nearestEnemy != null)
        {
            nearestEnemy.GetComponent<Animator>().speed = 1f;
        }
    }

    public Vector3 EnemyPos()
    {
        Transform enemy = nearestEnemy.GetComponent<Transform>();
        Vector3 enemypos = new Vector3(enemy.position.x, transform.position.y, enemy.position.z);
        return enemypos;
    }
    private bool Attackable()
    {
        distance = Vector3.Distance(transform.position, EnemyPos());
        return distance < 0.55f;
    }

    public void PartcileFighter()
    {
        FightParticleR.SetActive(true);
        FightParticleL.SetActive(true);
        StartCoroutine(fightClose());
    }

    public void Growth(float _variable)
    {
        transform.localScale = new Vector3(
            transform.localScale.x + _variable,
            transform.localScale.y + _variable,
            transform.localScale.z + _variable
            );
    }

    public void NewRandom()
    {
        random = Random.Range(0, 3);
    }

    IEnumerator fightClose()
    {
        yield return new WaitForSeconds(.2f);
        FightParticleR.SetActive(false);
        FightParticleL.SetActive(false);
    }
}
