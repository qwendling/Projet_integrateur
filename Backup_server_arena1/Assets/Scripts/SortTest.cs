<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SortTest : WeaponTest {

	public GameObject projectile;
	//public Color couleurTir;
	public AudioClip Clip;

	public static List<SortTest> sorts = new List<SortTest> ();

	public int range;

	// Use this for initialization
	void Start () {
		//Clip.enabled = true;
	}

	// Update is called once per frame
	void Update () {

	}

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
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SortTest : WeaponTest {

	public GameObject projectile;
	//public Color couleurTir;
	public AudioClip Clip;

	public static List<SortTest> sorts = new List<SortTest> ();

	public int range;

	// Use this for initialization
	void Start () {
		//Clip.enabled = true;
	}

	// Update is called once per frame
	void Update () {

	}

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
>>>>>>> origin/master
