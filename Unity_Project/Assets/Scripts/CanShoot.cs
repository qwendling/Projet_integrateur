using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CanShoot : NetworkBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!isLocalPlayer)
            return;
        if (Input.GetButtonDown("Fire1"))
        {
			CmdFire ();
        }
	}

	[Command]
	public void CmdFire () {
		Weapon W = gameObject.GetComponent<ToolSwap> ()._activeItem.GetComponent<Weapon> ();
		if (W is Arme) {
			Arme A = (Arme)W;
			print ("Tir avec une arme.");
			GameObject bullet = Instantiate(A.projectile, A.FireSpot.transform.position, Quaternion.identity) as GameObject;
			bullet.GetComponent<MeshRenderer>().material.color = A.couleurTir;
			bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
			NetworkServer.Spawn (bullet);
			Destroy (bullet, 2.0f);
		} else if (W is Sort) {
			print ("Tir avec un sort.");
		} else {
			print ("Tir avec les mains nues.");
		}
		//RpcFire ();
	}

	[ClientRpc]
	public void RpcFire () {
		gameObject.GetComponent<ToolSwap> ()._activeItem.GetComponent<Weapon> ().Shoot ();
	}
}
