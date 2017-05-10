using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Radar : NetworkBehaviour {

	public GameObject radarPlayer;
	public GameObject radarOtherPlayer;
	// public GameObject player;
	public GameObject radarArena;
	private float offset = 5.0f;

	void Start () {
		if(isLocalPlayer){
			radarArena.SetActive (true);
			radarPlayer.SetActive(true);
			radarOtherPlayer.SetActive(false);
		}
		else
		{
			radarArena.SetActive (false);
			radarPlayer.SetActive(false);
			radarOtherPlayer.SetActive(true);
		}
		
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
		createRadarObjects();
	}
	
	//player appears on radar for 5 seconds;
	void createRadarObjects()
	{
		foreach(GameObject go in GameObject.FindGameObjectsWithTag("Player")) 
		{
			if(!isLocalPlayer)
			{
				radarOtherPlayer.SetActive(true);
			}
			// if((player.transform.position.y >= (go.transform.position.y - offset) && player.transform.position.y <= (go.transform.position.y + offset ))&&(!isLocalPlayer))
			// {
				// Destroy(Instantiate(radarPrefab, go.transform.position, Quaternion.identity),5.0f);
				// Instantiate(radarPrefab, go.transform.position, Quaternion.identity);
			// }
		}
	}
}
