using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Radar : NetworkBehaviour {

	public GameObject radarPrefab;
	public GameObject player;
	public GameObject radarArena;
	private float offset = 5.0f;

	void Start () {
		if(isLocalPlayer){
			radarArena.SetActive (true);
		}
		else
		{
			radarArena.SetActive (false);
		}
		createRadarObjects();
	}
	
	// Update is called once per frame
	void Update () {
		// foreach(GameObject go in GameObject.FindGameObjectsWithTag("Player")) 
		// {
			// if(je joueur tire)
			// {
				// createRadarObjects();
			// }
		// }
	}
	
	//player appears on radar for 5 seconds;
	void createRadarObjects()
	{
		foreach(GameObject go in GameObject.FindGameObjectsWithTag("Player")) 
		{
			if((player.transform.position.y >= (go.transform.position.y - offset) && player.transform.position.y <= (go.transform.position.y + offset ))&&(!isLocalPlayer))
			{
				// Destroy(Instantiate(radarPrefab, go.transform.position, Quaternion.identity),5.0f);
				Instantiate(radarPrefab, go.transform.position, Quaternion.identity);
			}
		}
	}
}
