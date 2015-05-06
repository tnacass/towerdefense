using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour 
{

	public GameObject monster;
	public float spawnRate;
	public float spawnTime;

	// Use this for initialization
	void Start () 
	{
		InvokeRepeating("SpawnNext", spawnTime, spawnRate);
	}


	void SpawnNext() 
	{
		
		Instantiate(monster, transform.position, Quaternion.identity);
		
	}
}
