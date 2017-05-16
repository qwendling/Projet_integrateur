using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class InventoryGetChoices : MonoBehaviour {

	//public GameObject _Player;
	public GameObject _PlayerMenuChoices;
	public GameObject _NManager;
	public GameObject _Coordinator;
	public Arme[] _Weapons;
	public Sort[] _Spells;

	//public GameObject[] _WeaponsSpell;

	// Use this for initialization
	void Start () {
		while (_PlayerMenuChoices == null) {
			_PlayerMenuChoices = GameObject.Find ("PlayerChoices");
		}
		while (_NManager == null) {
			_NManager = GameObject.Find ("NetworkManager");
		}

		while (_Coordinator == null) {
			_Coordinator = GameObject.Find ("Coordinator");
		}

		_Coordinator.GetComponent<Server_PlayerList> ().PlayerJoinedTheGame (_PlayerMenuChoices.GetComponent<EmptyObject_PlayerChoices> ()._Name);

		GameObject _Wep1 = (GameObject) Instantiate (_PlayerMenuChoices.GetComponent < EmptyObject_PlayerChoices> ()._Wep1, transform.position, Quaternion.identity);
		GameObject _Wep2 = (GameObject) Instantiate (_PlayerMenuChoices.GetComponent < EmptyObject_PlayerChoices> ()._Wep2, transform.position, Quaternion.identity);
		GameObject _Wep3 = (GameObject) Instantiate (_PlayerMenuChoices.GetComponent < EmptyObject_PlayerChoices> ()._Wep3, transform.position, Quaternion.identity);

		_Wep1.name = "Weapon1";
		_Wep2.name = "Weapon2";
		_Wep3.name = "Weapon3";

		_Wep1.transform.parent = transform;
		_Wep2.transform.parent = transform;
		_Wep3.transform.parent = transform;
		Arme.armes = new List<Arme> ();
		Sort.sorts = new List<Sort> ();

		DBConnect db_link = new DBConnect ();

		db_link.init (_NManager.GetComponent<NetworkManager>().networkAddress);

		_Weapons = Arme.armes.ToArray();
		_Spells = Sort.sorts.ToArray();

		if(_Wep1.tag == "Weapon")
	{
		_Wep1.GetComponent<Arme> ().cadence = _Weapons [_Wep1.GetComponent<Arme> ().id].cadence;
		_Wep1.GetComponent<Arme> ().degat = _Weapons[_Wep1.GetComponent<Arme> ().id].degat;
		_Wep1.GetComponent<Arme> ().vitesse = _Weapons[_Wep1.GetComponent<Arme> ().id].vitesse;
		_Wep1.GetComponent<Arme> ().range = _Weapons[_Wep1.GetComponent<Arme> ().id].range;
		_Wep1.GetComponent<Arme> ().nom = _Weapons[_Wep1.GetComponent<Arme> ().id].nom;
	}
	else if(_Wep1.tag == "Spell"){
		_Wep1.GetComponent<Sort> ().cadence = _Spells [_Wep1.GetComponent<Sort> ().id].cadence;
		_Wep1.GetComponent<Sort> ().degat = _Spells[_Wep1.GetComponent<Sort> ().id].degat;
		_Wep1.GetComponent<Sort> ().vitesse = _Spells[_Wep1.GetComponent<Sort> ().id].vitesse;
		_Wep1.GetComponent<Sort> ().range = _Spells[_Wep1.GetComponent<Sort> ().id].range;
		_Wep1.GetComponent<Sort> ().nom = _Spells[_Wep1.GetComponent<Sort> ().id].nom;
	}
	if(_Wep2.tag == "Weapon")
	{
		_Wep2.GetComponent<Arme> ().cadence = _Weapons[_Wep2.GetComponent<Arme> ().id].cadence;
		_Wep2.GetComponent<Arme> ().degat = _Weapons[_Wep2.GetComponent<Arme> ().id].degat;
		_Wep2.GetComponent<Arme> ().vitesse = _Weapons[_Wep2.GetComponent<Arme> ().id].vitesse;
		_Wep2.GetComponent<Arme> ().range = _Weapons[_Wep2.GetComponent<Arme> ().id].range;
		_Wep2.GetComponent<Arme> ().nom = _Weapons[_Wep2.GetComponent<Arme> ().id].nom;
	}
	else if(_Wep2.tag == "Spell"){
		_Wep2.GetComponent<Sort> ().cadence = _Spells[_Wep2.GetComponent<Sort> ().id].cadence;
		_Wep2.GetComponent<Sort> ().degat = _Spells[_Wep2.GetComponent<Sort> ().id].degat;
		_Wep2.GetComponent<Sort> ().vitesse = _Spells[_Wep2.GetComponent<Sort> ().id].vitesse;
		_Wep2.GetComponent<Sort> ().range = _Spells[_Wep2.GetComponent<Sort> ().id].range;
		_Wep2.GetComponent<Sort> ().nom = _Spells[_Wep2.GetComponent<Sort> ().id].nom;
	}
	if(_Wep3.tag == "Weapon")
	{
		_Wep3.GetComponent<Arme> ().cadence = _Weapons[_Wep3.GetComponent<Arme> ().id].cadence;
		_Wep3.GetComponent<Arme> ().degat = _Weapons[_Wep3.GetComponent<Arme> ().id].degat;
		_Wep3.GetComponent<Arme> ().vitesse = _Weapons[_Wep3.GetComponent<Arme> ().id].vitesse;
		_Wep3.GetComponent<Arme> ().range = _Weapons[_Wep3.GetComponent<Arme> ().id].range;
		_Wep3.GetComponent<Arme> ().nom = _Weapons[_Wep3.GetComponent<Arme> ().id].nom;
	}
	else if(_Wep3.tag == "Spell"){
		_Wep3.GetComponent<Sort> ().cadence = _Spells[_Wep3.GetComponent<Sort> ().id].cadence;
		_Wep3.GetComponent<Sort> ().degat = _Spells[_Wep3.GetComponent<Sort> ().id].degat;
		_Wep3.GetComponent<Sort> ().vitesse = _Spells[_Wep3.GetComponent<Sort> ().id].vitesse;
		_Wep3.GetComponent<Sort> ().range = _Spells[_Wep3.GetComponent<Sort> ().id].range;
		_Wep3.GetComponent<Sort> ().nom = _Spells[_Wep3.GetComponent<Sort> ().id].nom;}
	}




		// Update is called once per frame
		void Update () {

		}
}
