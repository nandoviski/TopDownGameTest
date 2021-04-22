using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] GameObject PlayerDetectionPoint;
    [SerializeField] float DetectionRadius = 3f;

    GameObject target;

    void Update()
    {
        
    }

	void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.gameObject.tag == "Player")
        {
            //Start Chasing
            target = collision.gameObject;
            Debug.Log($"Start Chasing: {collision.gameObject.name}");
        }
	}

	void OnTriggerStay2D(Collider2D collision)
	{
        if (collision.gameObject.tag == "Player")
        {
            //Start Chasing
            Debug.Log($"stay Chasing: {collision.gameObject.name}");
        }
    }

	void OnTriggerExit2D(Collider2D collision)
	{
        if (collision.gameObject.tag == "Player")
        {
            //Stop Chasing
            target = null;
            Debug.Log($"Stop Chasing: {collision.gameObject.name}");
        }
    }

	void OnDrawGizmosSelected()
    {
        //if (PlayerDetectionPoint != null)
        //{
        //    // Just draw a circle in the editor, for help us to ajust it
        //    Gizmos.DrawWireSphere(PlayerDetectionPoint.transform.position, DetectionRadius);
        //}
    }
}
