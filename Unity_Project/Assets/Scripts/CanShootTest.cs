﻿using System.Collections;
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
		PlayerHealthTest ph = gameObject.GetComponent<PlayerHealthTest> ();

		if (W is ArmeTest) {
			// Tir
			ArmeTest A = (ArmeTest)W;

			ph.protectionIsOn = false;
			GameObject bullet = Instantiate(A.projectile, A.FireSpot.transform.position, W.FireSpot.transform.rotation) as GameObject;
			bullet.GetComponent<BulletTest> ().monJoueur = this.transform.gameObject;
			bullet.GetComponent<BulletTest> ().DAMAGE = 10;
			//bullet.GetComponent<AudioSource>().PlayOneShot (A.Clip);

			bullet.GetComponent<MeshRenderer>().material.color = A.couleurTir;
			bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * 1000);
			NetworkServer.Spawn (bullet);
			bullet.GetComponent<BulletTest> ().RpcPlayBruit();
			Destroy (bullet, 2.0f);
		} else if (W is SortTest) {

			SortTest S = (SortTest)W;

			if(S.id == 3){ //Fire

				ph.protectionIsOn = false;
				GameObject sort = Instantiate(S.projectile, S.FireSpot.transform.position, W.FireSpot.transform.rotation) as GameObject;
				//sort.GetComponent<AudioSource>().PlayOneShot (S.Clip);
				sort.GetComponent<Fire> ().monJoueur = this.transform.gameObject;
				sort.GetComponent<Fire> ().DAMAGE = 15;

				sort.GetComponent<Rigidbody>().AddForce(sort.transform.forward * 1000);
				NetworkServer.Spawn (sort);
				Destroy (sort, 1.0f);


			}
			else if(S.id == 4){  //Protection

				ph.protectionIsOn = true;
				GameObject sort = Instantiate(S.projectile, S.FireSpot.transform.position, W.FireSpot.transform.rotation) as GameObject;
				//sort.GetComponent<AudioSource>().PlayOneShot (S.Clip);
				NetworkServer.Spawn (sort);
				Destroy (sort, 0.5f);

			}
			else if(S.id == 5){ //Mine

				ph.protectionIsOn = false;
				GameObject sort = Instantiate(S.projectile, S.FireSpot.transform.position, W.FireSpot.transform.rotation) as GameObject;
				//sort.GetComponent<AudioSource>().PlayOneShot (S.Clip);
				sort.GetComponent<Fire> ().monJoueur = this.transform.gameObject;
				sort.GetComponent<Fire> ().DAMAGE = 5;

				NetworkServer.Spawn (sort);
				Vector3 pos = sort.transform.position;
				Destroy (sort, 30.0f);
				StartCoroutine(CmdMine(pos));




			}
			else if(S.id == 6){ //Teleportation

				ph.protectionIsOn = false;
				GameObject sort = Instantiate(S.projectile, S.FireSpot.transform.position, W.FireSpot.transform.rotation) as GameObject;
				//sort.GetComponent<AudioSource>().PlayOneShot (S.Clip);
				sort.GetComponent<Rigidbody>().AddForce(sort.transform.forward * 1000);
				NetworkServer.Spawn (sort);
				StartCoroutine(CmdTP());
				Destroy (sort,0.2f);
			}

		} else {
		}
	}



	IEnumerator CmdTP() {

				PlayerController p = gameObject.GetComponent<PlayerController> ();
				yield return new  WaitForSeconds(0.2f);
				for(int i=0;i<100;i++)
					p.CmdUpdateForwardSpeed(1);

	}


	IEnumerator CmdMine(Vector3 pos) {

				yield return new  WaitForSeconds(30.0f);
				GameObject nO = Resources.Load("ExplosionOrange") as GameObject;
				GameObject explosion = Instantiate(nO) as GameObject;
				explosion.transform.position = pos;
				Destroy (explosion,10.0f);
	}



}
