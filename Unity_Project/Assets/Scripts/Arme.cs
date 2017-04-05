using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Arme : Weapon {
    public int cadence;
    public GameObject projectile;
    public Color couleurTir;
    public AudioSource Bruit;

    // Use this for initialization
    void Start () {
        Bruit.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/*public override void Shoot()
    {
		GameObject bullet = Instantiate(projectile, FireSpot.transform.position, FireSpot.transform.rotation) as GameObject;
        bullet.GetComponent<MeshRenderer>().material.color = couleurTir;
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
		Destroy (bullet, 2.0f);
    }*/
}
