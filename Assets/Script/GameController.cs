using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject monster;
	public GameObject spawner;
	public float spawnRate;

	public Button singleTowerButton;
	public Button AoeTowerButton;

	public GameObject towerPrefab1;
	public GameObject towerPrefab2;
	public Transform buildPlaceRoot;
	private GameObject lastHitObject;
	RaycastHit hit;

	private int income;
	public Text incomeText;

	// Use this for initialization
	void Start () {

		income = 100;
		updateIncome ();
		InvokeRepeating("SpawnNext", spawnRate, spawnRate);
		singleTowerButton.interactable = false;
		AoeTowerButton.interactable = false;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hitInfo = new RaycastHit();
			bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
			if (hit) 
			{
				Debug.Log("Hit " + hitInfo.transform.gameObject.name);
				if (hitInfo.transform.gameObject.tag == "PlacementPlane_open")
				{
					lastHitObject = hitInfo.collider.gameObject;
					singleTowerButton.interactable = true;
					AoeTowerButton.interactable = true;
					Debug.Log ("It's working!");
				} else {
					singleTowerButton.interactable = false;
					AoeTowerButton.interactable = false;
					Debug.Log ("nopz");
				}
			} else {
				Debug.Log("No hit");
			}
		} 
	
	}
	

	void SpawnNext() 
	{
		
		Instantiate(monster, spawner.transform.position, Quaternion.identity);
		
	}

	public void IncreaseIncome(int newIncome)
	{
		income += newIncome;
		updateIncome ();
	}

	public void updateIncome()
	{
		incomeText.text = "Income: " + income;
	}

	public void DecreaseIncome(int newIncome)
	{
		income -= newIncome;
		updateIncome ();
	}



	public void CreateTower1()
	{

		if (lastHitObject.tag == "PlacementPlane_open" && income >= 50) {
			GameObject newStructure = Instantiate (towerPrefab1);
			newStructure.transform.position = lastHitObject.transform.position + Vector3.up;
			DecreaseIncome(50);
			lastHitObject.tag = "PlacementPlane_taken";

		}
	}

	public void CreateTower2()
	{
		if (lastHitObject.tag == "PlacementPlane_open" && income >= 50) {
			GameObject newStructure = Instantiate (towerPrefab2);
			newStructure.transform.position = lastHitObject.transform.position + Vector3.up;
			DecreaseIncome(50);
			lastHitObject.tag = "PlacementPlane_taken";
		}
	}
}
