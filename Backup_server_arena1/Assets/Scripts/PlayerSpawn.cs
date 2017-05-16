using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour {

	public GameObject _SpawnPoints;


	// Use this for initialization
	void Start () {
		_SpawnPoints = GameObject.Find ("SpawnPoints");
		RandomSpawn ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RandomSpawn(){

		int rand = Random.Range (0, _SpawnPoints.transform.childCount);
		this.transform.position = _SpawnPoints.transform.GetChild (rand).transform.position;
	}
}
