using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Arme : Weapon {
    public int cadence;
    public GameObject projectile;
    public Color couleurTir;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Shoot()
    {
        GameObject bullet = Instantiate(projectile, FireSpot.transform.position, Quaternion.identity) as GameObject;
        bullet.GetComponent<MeshRenderer>().material.color = couleurTir;
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
        NetworkServer.Spawn(bullet);
        Destroy(bullet, 2.0f);
    }
}
