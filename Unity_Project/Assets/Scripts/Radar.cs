using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour {

	public GameObject radarPrefab;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		createRadarObjects();
	}

	void createRadarObjects()
	{
		foreach(GameObject go in GameObject.FindGameObjectsWithTag("Player")) 
		{
			Destroy(Instantiate(radarPrefab, go.transform.position, Quaternion.identity),0.1f);
		}
	}
}
