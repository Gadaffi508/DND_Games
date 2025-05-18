using UnityEngine;
using UnityEngine.UI;

public abstract class Health : MonoBehaviour
{
    public float _health;
    public GameObject DieParticle;
    public GameObject m_diedSound;
    public GameManager manager;

    public static Health health;
    [SerializeField] private Image _healtbar;
    [SerializeField] private float maxHealth;

    private void Awake()
    {
        health = this;
        maxHealth = _health;
    }

    public abstract void Takedamage(int damage);
    public abstract void Die();



    public void UpdateHealthBar()
    {
        _healtbar.fillAmount = _health / maxHealth;
    }
}
