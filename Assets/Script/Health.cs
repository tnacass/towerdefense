using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {


	private TextMesh health;
	private GameController gameController;
	public int creepIncome;

	// Use this for initialization
	void Start () 
	{

		health = GetComponent<TextMesh>() ;
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		transform.forward = Camera.main.transform.forward;
	
	}

	// Return the current Health by counting the '-'
	
	public int CurrentHealth() 
	{
		
		return health.text.Length;
		
	}
	
	
	
	// Decrease the current Health by removing one '-'
	
	public void DecreaseHealth() 
	{
		
		if (CurrentHealth () > 1) {
			
			health.text = health.text.Remove (health.text.Length - 1);
		} else {
			
			Destroy (transform.parent.gameObject);
			if(transform.parent.gameObject.tag == "Castle")
			{
				Application.LoadLevel(2);
			}
			else
			{
				gameController.IncreaseIncome(creepIncome);

			}
		}
		
	}



}
