using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ArmeTest : WeaponTest {

	public GameObject projectile;
	public Color couleurTir;
	public AudioClip Clip;

	public static List<ArmeTest> armes = new List<ArmeTest> ();

	public int range;
	/*
	public ArmeTest(int id,string nom, float cadence, int degat, int range, float vitesseBullet) : base(id, nom, cadence, degat, vitesseBullet){
		this.nom = nom;
		this.cadence = cadence;
		this.degat = degat;
		this.range = range;
		this.vitesse = vitesseBullet;
	}*/

	// Use this for initialization
	void Start () {
		//Clip.enabled = true;
	}

	// Update is called once per frame
	void Update () {

	}
	/*
	public override void Shoot()
	{
		GameObject bullet = Instantiate(projectile, FireSpot.transform.position, FireSpot.transform.rotation) as GameObject;
		bullet.GetComponent<MeshRenderer>().material.color = couleurTir;
		bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
		Destroy (bullet, 2.0f);
	}*/

	public int getId(){
		return id;
	}

	public string getNom(){
		return nom;
	}

	public float getCadence(){
		return cadence;
	}

	public int getDegat(){
		return degat;
	}
	public int getRange(){
		return range;
	}

	public float getVitesseBullet(){
		return vitesse;
	}

	public int getSurchauffe(){
		return surchauffe;
	}
}
