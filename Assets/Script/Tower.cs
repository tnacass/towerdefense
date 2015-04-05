using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour 
{
	public GameObject bullet;
	public float rotationSpeed;

	void Update () 
	{
		transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed, Space.World);
	
	}

	void OnTriggerEnter(Collider co)
	{
		
		if (co.GetComponent<Monster>())
		{
			GameObject g = (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);
			g.GetComponent<Bullet>().target = co.transform;
			
		}
		
	}

}
