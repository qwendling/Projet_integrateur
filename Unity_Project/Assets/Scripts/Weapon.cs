﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Weapon : NetworkBehaviour {
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
