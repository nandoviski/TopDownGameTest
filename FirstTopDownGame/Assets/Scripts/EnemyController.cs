using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] HealthBar healthBar;

    float maxHealth = 100f;
    float currentHealth;
    Animator animator;

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        healthBar.SetMaxHealth((int)maxHealth);
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
