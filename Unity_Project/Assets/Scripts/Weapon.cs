using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    public int degat;
    public string nom;
    public GameObject FireSpot;
    public float vitesse = 1;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual void Shoot()
    {
        print("Tir de : " + nom);
    }
}
