using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryGetChoices : MonoBehaviour {

	//public GameObject _Player;
	public GameObject _PlayerMenuChoices;

	// Use this for initialization
	void Start () {
		while (_PlayerMenuChoices == null) {
			_PlayerMenuChoices = GameObject.Find ("PlayerChoices");
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




	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
