<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Fire : NetworkBehaviour {
	public int DAMAGE = 0;


	[SyncVar]
	public GameObject monJoueur;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter (Collider hit) {
		if (!isServer)
			return;

		if (hit.tag == "Player" && monJoueur != hit.gameObject) {
			hit.gameObject.GetComponent<PlayerHealth> ().TakeDamage (DAMAGE, monJoueur.GetComponent<SkinChoice>()._PlayerName);
			RpcDestroyBullet ();
		}
		if (hit.tag == "Wall") {
			RpcDestroyBullet ();
		}
	}

	[ClientRpc]
	void RpcDestroyBullet() {
		gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
		Destroy (gameObject, 2.0f);
	}

	[ClientRpc]
	public void RpcPlayBruit(){
		//gameObject.GetComponent<AudioSource>().PlayOneShot (monJoueur.GetComponent<ToolSwapTest>()._activeItem.GetComponent<ArmeTest>().Clip);
	}
}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Fire : NetworkBehaviour {
	public int DAMAGE = 0;


	[SyncVar]
	public GameObject monJoueur;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter (Collider hit) {
		if (!isServer)
			return;

		if (hit.tag == "Player" && monJoueur != hit.gameObject) {
			hit.gameObject.GetComponent<PlayerHealth> ().TakeDamage (DAMAGE, monJoueur.GetComponent<SkinChoice>()._PlayerName);
			RpcDestroyBullet ();
		}
		if (hit.tag == "Wall") {
			RpcDestroyBullet ();
		}
	}

	[ClientRpc]
	void RpcDestroyBullet() {
		gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
		Destroy (gameObject, 2.0f);
	}

	[ClientRpc]
	public void RpcPlayBruit(){
		//gameObject.GetComponent<AudioSource>().PlayOneShot (monJoueur.GetComponent<ToolSwapTest>()._activeItem.GetComponent<ArmeTest>().Clip);
	}
}
>>>>>>> origin/master
