using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public HealthBar healthBar;

    float maxHealth = 100;
    float currentHealth;
    Animator animator;//

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        healthBar.SetMaxHealth((int)maxHealth);
    }

    void Update()
    {
    }

    public void UpdateHealth(float quantity)
    {
        currentHealth += quantity;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
        healthBar.SetHealth((int)currentHealth);
    }

	void Die()
	{
        animator.SetTrigger("Death");
        Destroy(this.gameObject, 0.5f);
	}
}
