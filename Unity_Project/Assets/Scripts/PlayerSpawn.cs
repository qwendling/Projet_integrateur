using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSpawn : NetworkBehaviour {

	public GameObject _SpawnPoints;


	// Use this for initialization
	void Start () {
		_SpawnPoints = GameObject.Find ("SpawnPoints");
		if (isLocalPlayer) {
			CmdRandomSpawn ();
		}


	}

	// Update is called once per frame
	void Update () {

	}

	[Command]
	public void CmdRandomSpawn(){
			Debug.Log ("pouet");
			int rand = Random.Range (0, _SpawnPoints.transform.childCount);
			Debug.Log (_SpawnPoints.transform.GetChild (rand).transform.position);
			Vector3 spawnPosition = _SpawnPoints.transform.GetChild (rand).transform.position;
			this.transform.position = spawnPosition;
			RpcRandomSpawn (spawnPosition);
	}

	[ClientRpc]
	public void RpcRandomSpawn(Vector3 newPos){
		if(isLocalPlayer){
			this.transform.position = newPos;
		}
	}
}
