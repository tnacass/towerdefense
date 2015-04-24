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
		if (health) 
		{
			health.DecreaseHealth();
			Destroy(gameObject);
			
		}
		
	}

}
