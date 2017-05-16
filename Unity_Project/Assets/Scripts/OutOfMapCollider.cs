using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class OutOfMapCollider : NetworkBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider hit) {
		if (!isServer) {
			return;
		}
		Debug.Log (hit.tag);
		if (hit.tag == "Player")
			hit.gameObject.GetComponent<PlayerHealth> ().TakeDamage (666, null);
	}
}
