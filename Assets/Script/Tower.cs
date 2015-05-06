using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour 
{
	public GameObject bullet;
	public float rotationSpeed;
	public float fireRate;
	public Transform myTarget;
	private float nextFire;

	void Update () 
	{
		transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed, Space.World);
		if (myTarget) 
		{
			if (Time.time > nextFire) 
			{
				FireBullet ();
			}
		}
	}

	



	void OnTriggerEnter(Collider co)
	{
		
		if (co.tag == "Creep")
		{
				myTarget = co.transform;
		}
		
	}

	void OnTriggerExit(Collider co)
	{
		if (co.gameObject.transform == myTarget) {
			myTarget = null;
		}
	}

	void FireBullet()
	{
		GameObject g = (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);
		g.GetComponent<Bullet> ().target = myTarget;
		nextFire = Time.time + fireRate;
	}
	
}