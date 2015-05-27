using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{
	public float speed;

	public Transform target;

	void FixedUpdate()
	{
		if (target) 
		{	
			         
			Vector3 bulletDirection = target.position - transform.position;
			GetComponent<Rigidbody> ().velocity = bulletDirection.normalized * speed;

		} 
		else 
		{
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter(Collider co) 
	{
		Health health = co.GetComponentInChildren<Health>();
		NavMeshAgent nav = co.GetComponentInChildren<NavMeshAgent> ();
		if (health) 
		{
			health.DecreaseHealth();
			Destroy(gameObject);
			
		}

		if (GetComponent<Bullet> ().tag == "SlowBullet")
		{
			Debug.Log("SlowBullet");
			nav.speed = nav.speed / 2;
			
		}
		
	}

}
