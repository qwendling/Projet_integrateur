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
		//CmdTP(); //pour la téléportation, fonctionne presque
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
				sort.GetComponent<Rigidbody>().AddForce(sort.transform.forward * 1000);
				NetworkServer.Spawn (sort);
				Destroy (sort, 2.0f);
			}
			else if(S.id == 4){  //Protection

				ph.protectionIsOn = true;
				GameObject sort = Instantiate(S.projectile, S.FireSpot.transform.position, W.FireSpot.transform.rotation) as GameObject;
				//sort.GetComponent<AudioSource>().PlayOneShot (S.Clip);
				NetworkServer.Spawn (sort);
				Destroy (sort, 5.0f);

			}
			else if(S.id == 5){ //Push, ici pas encore mis le bon code car ne fonctionne pas bien pour l'instant

				ph.protectionIsOn = false;
				GameObject sort = Instantiate(S.projectile, S.FireSpot.transform.position, W.FireSpot.transform.rotation) as GameObject;
				//sort.GetComponent<AudioSource>().PlayOneShot (S.Clip);
				sort.GetComponent<Rigidbody>().AddForce(sort.transform.forward * 1000);
				NetworkServer.Spawn (sort);
				Destroy (sort, 2.0f);

			}
			else if(S.id == 6){ //Teleportation, fonctionne presque

				ph.protectionIsOn = false;
				GameObject sort = Instantiate(S.projectile, S.FireSpot.transform.position, W.FireSpot.transform.rotation) as GameObject;
				//sort.GetComponent<AudioSource>().PlayOneShot (S.Clip);
				sort.GetComponent<Rigidbody>().AddForce(sort.transform.forward * 1000);
				NetworkServer.Spawn (sort);
				Destroy (sort, 6.0f);
			}



		} else {
		}
	}






//pour la téléportation, fonctionne presque
	[Command]
	public void CmdTP() {

		WeaponTest W = gameObject.GetComponent<ToolSwapTest> ()._activeItem.GetComponent<WeaponTest> ();
		if (W is SortTest) {

			SortTest S = (SortTest)W;

			if(S.id == 6){

					if(Input.GetButton("Fire2")){

						if (S != null)
								transform.position = S.transform.position;
					}
			}

		}
	}


}
