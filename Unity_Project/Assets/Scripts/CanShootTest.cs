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

	}

	[Command]
	public void CmdFire () {
		WeaponTest W = gameObject.GetComponent<ToolSwapTest> ()._activeItem.GetComponent<WeaponTest> ();
		if (W is ArmeTest) {
			// Tir
			ArmeTest A = (ArmeTest)W;
			GameObject bullet = Instantiate(A.projectile, A.FireSpot.transform.position, W.FireSpot.transform.rotation) as GameObject;
			bullet.GetComponent<BulletTest> ().monJoueur = gameObject;
			bullet.GetComponent<BulletTest> ().DAMAGE = 10;
			//bullet.GetComponent<AudioSource>().PlayOneShot (A.Clip);

			bullet.GetComponent<MeshRenderer>().material.color = A.couleurTir;
			bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * 1000);
			NetworkServer.Spawn (bullet);
			bullet.GetComponent<BulletTest> ().RpcPlayBruit();
			Destroy (bullet, 2.0f);
		} else if (W is Sort) {
		} else {
		}
	}
}