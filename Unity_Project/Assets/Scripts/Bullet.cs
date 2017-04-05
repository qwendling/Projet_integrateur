using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public int DAMAGE = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider hit) {
		if (hit.tag == "Player") {
			hit.gameObject.GetComponent<PlayerHealth> ().TakeDamage (DAMAGE);
		}
		Destroy (gameObject);
	}
}
