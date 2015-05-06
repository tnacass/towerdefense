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

	// Use this for initialization
	void Start () {

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

	public void CreateTower1()
	{
		if (lastHitObject.tag == "PlacementPlane_open") {
			GameObject newStructure = Instantiate (towerPrefab1);
			newStructure.transform.position = lastHitObject.transform.position + Vector3.up;
			lastHitObject.tag = "PlacementPlane_taken";
		}
	}

	public void CreateTower2()
	{
		if (lastHitObject.tag == "PlacementPlane_open") {
			GameObject newStructure = Instantiate (towerPrefab2);
			newStructure.transform.position = lastHitObject.transform.position + Vector3.up;
			lastHitObject.tag = "PlacementPlane_taken";
		}
	}
}
