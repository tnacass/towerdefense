using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {

	public float duration;


	// Use this for initialization
	void Start () 
	{
		duration = 2;
		// Navigate to Castle
		
		GameObject castle = GameObject.Find("Castle");
		
		if (castle)
			
			GetComponent<NavMeshAgent>().destination = castle.transform.position;
	
	}

	void Update()
	{
		RecoverTime ();
	}

	void OnTriggerEnter(Collider co) {
		
		// If castle then deal Damage
		
		if (co.name == "Castle") {
			
			co.GetComponentInChildren<Health>().DecreaseHealth();
			Destroy(gameObject);
		}
		
	}

	void RecoverTime()
	{

		if (GetComponentInChildren<NavMeshAgent> ().speed <= 2.5) 
		{
			duration = duration - Time.deltaTime;
			if(duration <= 0)
			{
				GetComponentInChildren<NavMeshAgent>().speed = GetComponentInChildren<NavMeshAgent>().speed * 2;
			}

		}

	}

}
