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
			gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
			gameObject.GetComponent<Renderer> ().enabled = false;
			gameObject.GetComponent<Collider> ().enabled = false;
			Destroy (gameObject, 2.0f);
		}
		if (hit.tag == "Wall") {
			gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
			gameObject.GetComponent<Renderer> ().enabled = false;
			gameObject.GetComponent<Collider> ().enabled = false;
			Destroy (gameObject, 2.0f);
		}
	}
}
