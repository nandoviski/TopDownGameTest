using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    float minDistance = .5f;
    float speed = 2f;
    GameObject target;
    EnemyController enemyController;

    Animator animator;
    bool isMoving;
    Vector2 movingTo;

    void Start()
	{
        animator = GetComponent<Animator>();
        enemyController = GetComponent<EnemyController>();
    }

	void FixedUpdate()
    {
        isMoving = false;

        if (target != null && enemyController.CurrentHealth > 0)
        {
            var lastPos = transform.position;
            if (Vector2.Distance(transform.position, target.transform.position) > minDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
                isMoving = true;
            }
            movingTo = (transform.position - lastPos).normalized; // calculate the direction we moving
        }
        Animations();
    }

    void Animations()
    {
        animator.SetFloat("Horizontal", movingTo.x);
        animator.SetFloat("Vertical", movingTo.y);
        animator.SetFloat("Speed", (isMoving ? 1 : 0));
    }

	void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.gameObject.tag == "Player")
        {
            target = collision.gameObject;
        }
	}

	void OnTriggerExit2D(Collider2D collision)
	{
        if (collision.gameObject.tag == "Player")
        {
            target = null;
        }
    }
}
