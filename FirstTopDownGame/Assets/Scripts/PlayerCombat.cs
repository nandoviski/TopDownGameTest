using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform AttackPoint;
    public LayerMask enemyLayers;

    PlayerController playerController;
    float attackDelay = 1f;
    Animator animator;
    float attackPointMoveDistance = 0.20f;
    float attackRange = 0.6f;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        if (attackDelay != 0f)
        {
            attackDelay -= Time.deltaTime;
            if (attackDelay < 0f)
                attackDelay = 0f;
        }

        MoveAttackerCircle();

        if (Input.GetKeyDown(KeyCode.Space) && attackDelay == 0f) // Melee attack
        {
            // Play animation
            animator.SetTrigger("Attack");
            attackDelay = .2f;

            // Used to draw a circle in the position and get all objects with the LayerMask passed in the parameters
            var hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLayers);

			foreach (var item in hitEnemies)
			{
                item.GetComponent<EnemyController>()?.UpdateHealth(-playerController.AttackPower);
			}
        }
    }

    void MoveAttackerCircle()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");

		if (horizontal < -0.01)
		{
            AttackPoint.position = new Vector3(transform.position.x - attackPointMoveDistance, transform.position.y, transform.position.z);
		}
		else if (horizontal > 0.01)
		{
            AttackPoint.position = new Vector3(transform.position.x + attackPointMoveDistance, transform.position.y, transform.position.z);
		}
		else if (vertical < -0.01)
		{
            AttackPoint.position = new Vector3(transform.position.x, transform.position.y - (attackPointMoveDistance + 0.4f), transform.position.z);
		}
		else if (vertical > 0.01)
		{
            AttackPoint.position = new Vector3(transform.position.x, transform.position.y + attackPointMoveDistance, transform.position.z);
		}
	}

	void OnDrawGizmosSelected()
    {
        if (AttackPoint != null)
        {
            // Just draw a circle in the editor, for help us to ajust it
            Gizmos.DrawWireSphere(AttackPoint.position, attackRange);
        }
    }
}
