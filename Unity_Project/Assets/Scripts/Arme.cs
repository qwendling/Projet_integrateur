using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arme : Weapon {
    public int cadence;
    public GameObject projectile;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Cmdshoot()
    {
        GameObject bullet = Instantiate(projectile, FireSpot.transform.position, Quaternion.identity) as GameObject;
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
    }
}
