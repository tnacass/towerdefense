using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {


	public TextMesh castleHealth;

	// Use this for initialization
	void Start () 
	{

		castleHealth = GetComponent<TextMesh>() ;
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		transform.forward = Camera.main.transform.forward;
	
	}

	// Return the current Health by counting the '-'
	
	public int CurrentHealth() 
	{
		
		return castleHealth.text.Length;
		
	}
	
	
	
	// Decrease the current Health by removing one '-'
	
	public void DecreaseHealth() 
	{
		
		if (CurrentHealth() > 1)
			
			castleHealth.text = castleHealth.text.Remove(castleHealth.text.Length - 1);
		
		else
			
			Destroy(transform.parent.gameObject);
		
	}


}
