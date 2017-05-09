using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class InventoryGetChoices : MonoBehaviour {

	//public GameObject _Player;
	public GameObject _PlayerMenuChoices;
	public GameObject _NManager;

	// Use this for initialization
	void Start () {
		while (_PlayerMenuChoices == null) {
			_PlayerMenuChoices = GameObject.Find ("PlayerChoices");
		}
		while (_NManager == null) {
			_NManager = GameObject.Find ("NetworkManager");
		}

		GameObject _Wep1 = (GameObject) Instantiate (_PlayerMenuChoices.GetComponent < EmptyObject_PlayerChoices> ()._Wep1, transform.position, Quaternion.identity);
		GameObject _Wep2 = (GameObject) Instantiate (_PlayerMenuChoices.GetComponent < EmptyObject_PlayerChoices> ()._Wep2, transform.position, Quaternion.identity);
		GameObject _Wep3 = (GameObject) Instantiate (_PlayerMenuChoices.GetComponent < EmptyObject_PlayerChoices> ()._Wep3, transform.position, Quaternion.identity);

		_Wep1.name = "Weapon1";
		_Wep2.name = "Weapon2";
		_Wep3.name = "Weapon3";

		_Wep1.transform.parent = transform;
		_Wep2.transform.parent = transform;
		_Wep3.transform.parent = transform;

		DBConnect db_link = new DBConnect ();
		db_link.init (_NManager.GetComponent<NetworkManager>().networkAddress);


		_Wep1.GetComponent<ArmeTest> ().cadence = ArmeTest.armes [_Wep1.GetComponent<ArmeTest> ().id].cadence;
		_Wep1.GetComponent<ArmeTest> ().degat = ArmeTest.armes [_Wep1.GetComponent<ArmeTest> ().id].degat;
		_Wep1.GetComponent<ArmeTest> ().vitesse = ArmeTest.armes [_Wep1.GetComponent<ArmeTest> ().id].vitesse;

		_Wep2.GetComponent<ArmeTest> ().cadence = ArmeTest.armes [_Wep2.GetComponent<ArmeTest> ().id].cadence;
		_Wep2.GetComponent<ArmeTest> ().degat = ArmeTest.armes [_Wep2.GetComponent<ArmeTest> ().id].degat;
		_Wep2.GetComponent<ArmeTest> ().vitesse = ArmeTest.armes [_Wep2.GetComponent<ArmeTest> ().id].vitesse;


		_Wep3.GetComponent<ArmeTest> ().cadence = ArmeTest.armes [_Wep3.GetComponent<ArmeTest> ().id].cadence;
		_Wep3.GetComponent<ArmeTest> ().degat = ArmeTest.armes [_Wep3.GetComponent<ArmeTest> ().id].degat;
		_Wep3.GetComponent<ArmeTest> ().vitesse = ArmeTest.armes [_Wep3.GetComponent<ArmeTest> ().id].vitesse;


	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
