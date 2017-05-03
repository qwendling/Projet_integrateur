using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Bullet : NetworkBehaviour {
	public int DAMAGE = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider hit) {
		if (!isServer)
			return;
		
		if (hit.tag == "Player") {
			hit.gameObject.GetComponent<PlayerHealth> ().TakeDamage (DAMAGE);
			Destroy (gameObject);
		}
		if (hit.tag == "Wall") {
			Destroy (gameObject);
		}
	}
}
