using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerBonus : NetworkBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Heal (int amount) {
		GetComponent<PlayerHealth> ().HealUp (amount);
	}

	public void SpeedUp (float acc_factor) {
		GetComponent<PlayerController> ().RpcBoostSpeed (acc_factor);
	}
}
