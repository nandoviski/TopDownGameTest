using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    Vector2 movement;
    float moveSpeed = 6f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        movement = new Vector2(0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        MovementInput();
    }

	void FixedUpdate()
	{
        rb.velocity = movement * moveSpeed;
	}

	void MovementInput()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");

        //normalized: makes it always returs 1
        // - with it, we have a constant speed, without it, if we go diagnaly (for example), we will have a greater speed, because we are adding left and right to a number greater than 1
        movement = new Vector2(horizontal, vertical).normalized;

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        // store last player position to execute idle and attack animation in the right direction
        if (horizontal != 0 || vertical != 0)
        {
            animator.SetFloat("LastHorizontal", horizontal);
            animator.SetFloat("LastVertical", vertical);
        }
    }
}
