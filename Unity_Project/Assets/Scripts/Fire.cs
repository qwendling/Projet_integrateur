using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Fire : NetworkBehaviour {
	public int DAMAGE = 0;

	private Vector3 pos;

	public bool isMine = false;


	[SyncVar]
	public GameObject monJoueur;

	// Use this for initialization
	void Start () {

		if(isMine){
			pos = this.transform.position;
			Invoke("ExploseMine",30.0f);
		}

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
			ExploseMine();
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

	void ExploseMine() {
		isMine = false;
		GameObject nouvelObj = Resources.Load("ExplosionOrange") as GameObject;
		GameObject explosion = Instantiate(nouvelObj,pos,Quaternion.identity) as GameObject;
		Destroy (explosion,10.0f);
		Destroy (this.gameObject);
	}
}
