using UnityEngine;
using System.Collections;

public class BuildPlace : MonoBehaviour 
{
	//public GameObject[] allStructure;
	//public int structureIndex = 0;
	public GameObject towerPrefab1;
	public GameObject towerPrefab2;

	void OnMouseUpAsButton()
	{
		if (GetComponent<BuildPlace> ().tag == "PlacementPlane_open") 
		{	
			GameObject newStructure = Instantiate(towerPrefab1);
			newStructure.transform.position = transform.position + Vector3.up;


			GetComponent<BuildPlace>().tag = "PlacementPlane_taken";

		}
	}


	/*void SetBuildChoice(GameObject btnObject)
	{
		string btnName = btnObject.name;
		
		if (btnName == "ButtonAOE") {
			structureIndex = 0;
		} else if (btnName == "ButtonSingle") 
		{
			structureIndex = 1;
		}
	}*/

}
