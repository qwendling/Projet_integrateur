using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class InventoryGetChoices : MonoBehaviour {

	//public GameObject _Player;
	public GameObject _PlayerMenuChoices;
	public GameObject _NManager;
	public GameObject _Coordinator;
	public ArmeTest[] _Weapons;
	public SortTest[] _Spells;

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
		ArmeTest.armes = new List<ArmeTest> ();
		SortTest.sorts = new List<SortTest> ();

		DBConnect db_link = new DBConnect ();

		db_link.init (_NManager.GetComponent<NetworkManager>().networkAddress);

		_Weapons = ArmeTest.armes.ToArray();
		_Spells = SortTest.sorts.ToArray();

		if(_Wep1.tag == "Weapon")
	{
		_Wep1.GetComponent<ArmeTest> ().cadence = _Weapons [_Wep1.GetComponent<ArmeTest> ().id].cadence;
		_Wep1.GetComponent<ArmeTest> ().degat = _Weapons[_Wep1.GetComponent<ArmeTest> ().id].degat;
		_Wep1.GetComponent<ArmeTest> ().vitesse = _Weapons[_Wep1.GetComponent<ArmeTest> ().id].vitesse;
		_Wep1.GetComponent<ArmeTest> ().range = _Weapons[_Wep1.GetComponent<ArmeTest> ().id].range;
		_Wep1.GetComponent<ArmeTest> ().nom = _Weapons[_Wep1.GetComponent<ArmeTest> ().id].nom;
	}
	else if(_Wep1.tag == "Spell"){
		_Wep1.GetComponent<SortTest> ().cadence = _Spells [_Wep1.GetComponent<SortTest> ().id].cadence;
		_Wep1.GetComponent<SortTest> ().degat = _Spells[_Wep1.GetComponent<SortTest> ().id].degat;
		_Wep1.GetComponent<SortTest> ().vitesse = _Spells[_Wep1.GetComponent<SortTest> ().id].vitesse;
		_Wep1.GetComponent<SortTest> ().range = _Spells[_Wep1.GetComponent<SortTest> ().id].range;
		_Wep1.GetComponent<SortTest> ().nom = _Spells[_Wep1.GetComponent<SortTest> ().id].nom;
	}
	if(_Wep2.tag == "Weapon")
	{
		_Wep2.GetComponent<ArmeTest> ().cadence = _Weapons[_Wep2.GetComponent<ArmeTest> ().id].cadence;
		_Wep2.GetComponent<ArmeTest> ().degat = _Weapons[_Wep2.GetComponent<ArmeTest> ().id].degat;
		_Wep2.GetComponent<ArmeTest> ().vitesse = _Weapons[_Wep2.GetComponent<ArmeTest> ().id].vitesse;
		_Wep2.GetComponent<ArmeTest> ().range = _Weapons[_Wep2.GetComponent<ArmeTest> ().id].range;
		_Wep2.GetComponent<ArmeTest> ().nom = _Weapons[_Wep2.GetComponent<ArmeTest> ().id].nom;
	}
	else if(_Wep2.tag == "Spell"){
		_Wep2.GetComponent<SortTest> ().cadence = _Spells[_Wep2.GetComponent<SortTest> ().id].cadence;
		_Wep2.GetComponent<SortTest> ().degat = _Spells[_Wep2.GetComponent<SortTest> ().id].degat;
		_Wep2.GetComponent<SortTest> ().vitesse = _Spells[_Wep2.GetComponent<SortTest> ().id].vitesse;
		_Wep2.GetComponent<SortTest> ().range = _Spells[_Wep2.GetComponent<SortTest> ().id].range;
		_Wep2.GetComponent<SortTest> ().nom = _Spells[_Wep2.GetComponent<SortTest> ().id].nom;
	}
	if(_Wep3.tag == "Weapon")
	{
		_Wep3.GetComponent<ArmeTest> ().cadence = _Weapons[_Wep3.GetComponent<ArmeTest> ().id].cadence;
		_Wep3.GetComponent<ArmeTest> ().degat = _Weapons[_Wep3.GetComponent<ArmeTest> ().id].degat;
		_Wep3.GetComponent<ArmeTest> ().vitesse = _Weapons[_Wep3.GetComponent<ArmeTest> ().id].vitesse;
		_Wep3.GetComponent<ArmeTest> ().range = _Weapons[_Wep3.GetComponent<ArmeTest> ().id].range;
		_Wep3.GetComponent<ArmeTest> ().nom = _Weapons[_Wep3.GetComponent<ArmeTest> ().id].nom;
	}
	else if(_Wep3.tag == "Spell"){
		_Wep3.GetComponent<SortTest> ().cadence = _Spells[_Wep3.GetComponent<SortTest> ().id].cadence;
		_Wep3.GetComponent<SortTest> ().degat = _Spells[_Wep3.GetComponent<SortTest> ().id].degat;
		_Wep3.GetComponent<SortTest> ().vitesse = _Spells[_Wep3.GetComponent<SortTest> ().id].vitesse;
		_Wep3.GetComponent<SortTest> ().range = _Spells[_Wep3.GetComponent<SortTest> ().id].range;
		_Wep3.GetComponent<SortTest> ().nom = _Spells[_Wep3.GetComponent<SortTest> ().id].nom;}
	}




		// Update is called once per frame
		void Update () {

		}
}
