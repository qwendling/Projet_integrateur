using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour {

	public GameObject radarPrefab;
	public GameObject player;
	private float offset = 5.0f;

	void Start () {
		createRadarObjects();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	//player appears on radar for 5 seconds;
	void createRadarObjects()
	{
		foreach(GameObject go in GameObject.FindGameObjectsWithTag("Player")) 
		{

			if(player.transform.position.y >= (go.transform.position.y - offset) && player.transform.position.y <= (go.transform.position.y + offset ))
			{
				Destroy(Instantiate(radarPrefab, go.transform.position, Quaternion.identity),5.0f);
			}
		}
	}
}
