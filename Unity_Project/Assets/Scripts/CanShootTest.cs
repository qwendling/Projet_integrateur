using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CanShootTest : NetworkBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (!isLocalPlayer)
			return;
	}

	[Command]
	public void CmdFire () {
		Weapon W = gameObject.GetComponent<ToolSwapTest> ()._activeItem.GetComponent<Weapon> ();
		if (W is Arme) {
			Arme A = (Arme)W;
			A.Bruit.Play();
			GameObject bullet = Instantiate(A.projectile, A.FireSpot.transform.position, W.FireSpot.transform.rotation) as GameObject;
			bullet.GetComponent<MeshRenderer>().material.color = A.couleurTir;
			bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * 1000);
			NetworkServer.Spawn (bullet);
			Destroy (bullet, 2.0f);
		} else if (W is Sort) {
		} else {
		}
	}
}

