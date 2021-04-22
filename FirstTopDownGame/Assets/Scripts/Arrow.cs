using System;
using UnityEngine;

public class Arrow : MonoBehaviour
{
	[HideInInspector] public float ArrowDamage = 0f;
	float arrowVelocity = 5f;
	Rigidbody2D rb;

	void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void Start()
	{
		Destroy(gameObject, 4f); // will ALWAYS destroy this object after 4f
	}

	void FixedUpdate()
	{
		rb.velocity = transform.up * arrowVelocity;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{
			collision.gameObject.GetComponent<EnemyController>().UpdateHealth(-ArrowDamage);
		}

		Destroy(gameObject);
	}
}
