using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] HealthBar healthBar;

    public float CurrentHealth => currentHealth;

    float maxHealth = 100f;
    float currentHealth;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

	public void UpdateHealth(float quantity)
    {
        currentHealth += quantity;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
        healthBar.SetHealth(currentHealth);
    }

	void Die()
	{
        animator.SetTrigger("Death");
        Destroy(this.gameObject, 0.5f);
	}
}
