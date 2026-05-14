using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public float currentHealth;
    [SerializeField] protected float maxHealth;

    [SerializeField] protected float currentEnegy;
    [SerializeField] protected float maxEnegy;

    [HideInInspector] public bool isDie = false;
    [HideInInspector] public bool isHurt = false;

    [HideInInspector] public bool isShield = false;

    public HealthBar healthBar;
    public HealthBar enegyBar;

    private void Start()
    {
        if (healthBar != null)
        {
            healthBar.maxHealth = maxHealth;
            UpdateHealth();
        }

        if (enegyBar != null)
        {
            enegyBar.maxHealth = maxEnegy;
            UpdateEnegy();
        }
    }

    public void UpdateHealth()
    {
        if (healthBar != null) healthBar.currentHealth = currentHealth;
    }

    public void UpdateEnegy()
    {
        if(enegyBar!=null) enegyBar.currentHealth = currentEnegy;
    }

    public virtual void TakeDamage(float damage)
    {
        if (!isShield)
        {
            if (currentHealth - damage <= 0)
            {
                currentHealth = 0;
            }
            else
                currentHealth -= damage;
            if (healthBar != null)
                UpdateHealth();
        }
    }

    public void Heal(float heal)
    {
        if (currentHealth + heal > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
            currentHealth += heal;
        if (healthBar != null)
            UpdateHealth();
    }

    public void EnegyDecrease(float value)
    {
        if (currentEnegy - value <= 0)
        {
            currentEnegy = 0;
        }
        else
        {
            currentEnegy -= value;
            if (enegyBar != null)
                UpdateEnegy();
        }
    }

    public void EnegyIncrease()
    {
        if(currentEnegy + 1 > maxEnegy)
        {
            currentEnegy = maxEnegy;
        }
        else
        {
            currentEnegy += 1;
            if (enegyBar != null)
                UpdateEnegy();
        }
    }
}
