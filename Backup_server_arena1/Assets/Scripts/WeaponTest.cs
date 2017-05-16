using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTest : MonoBehaviour {

	public int id;
	public int degat;
	public float cadence;
	public string nom;
	public GameObject FireSpot;
	public float vitesse = 1;
	public int surchauffe;

	public WeaponTest(int id, string nom, float cadence, int degat, float vitesse){
		this.id = id;
		this.nom = nom;
		this.cadence = cadence;
		this.degat = degat;
		this.vitesse = vitesse;
	}

	public WeaponTest(){
		this.nom = "";
		this.cadence = 3;
		this.degat = 10;
		this.vitesse = 1;
	}

	/*public float timeBetweenTicks = 2;
	public float _timer = 2;*/
	// Use this for initialization
	void Start () {
		//GameObject _Player = GameObject.FindGameObjectWithTag ("Player");
	}

	// Update is called once per frame
	void Update () {
		/*if(CLICK GAUCHE GET DOWN){
			if(_timer <= 0){
				//shoot
				_timer = timeBetweenTicks;
			}
			else{
				_timer -= 1.0*Time.deltaTime;
			}
		}
		_timer = timeBetweenTicks;*/
	}

	public virtual void Shoot()
	{
		print("Tir de : " + nom);
	}
}