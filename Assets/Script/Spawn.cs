using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour 
{

	public GameObject monster;
	public float spawnRate;

	// Use this for initialization
	void Start () 
	{
		InvokeRepeating("SpawnNext", spawnRate, spawnRate);
	}


	void SpawnNext() 
	{
		
		Instantiate(monster, transform.position, Quaternion.identity);
		
	}
}
