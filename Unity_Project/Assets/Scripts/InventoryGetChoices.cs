using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class InventoryGetChoices : NetworkBehaviour {

	//public GameObject _Player;
	public GameObject _PlayerMenuChoices;
	public GameObject _NManager;
	public GameObject _Coordinator;
	public Arme[] _Weapons;
	public Sort[] _Spells;

	//public GameObject[] _WeaponsSpell;

	// Use this for initialization
	void Start () {
		if (!isLocalPlayer) {
			CmdInitInventaire ();
		}

		if (isLocalPlayer) {
			Debug.Log (" IS LOCAL PLAYER ");
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

			GameObject _Inventory = this.transform.FindChild ("Camera Pivot").transform.FindChild ("Inventory").gameObject;

			GameObject _Wep1 = (GameObject) Instantiate (_PlayerMenuChoices.GetComponent < EmptyObject_PlayerChoices> ()._Wep1, transform.position, Quaternion.identity);
			GameObject _Wep2 = (GameObject) Instantiate (_PlayerMenuChoices.GetComponent < EmptyObject_PlayerChoices> ()._Wep2, transform.position, Quaternion.identity);
			GameObject _Wep3 = (GameObject) Instantiate (_PlayerMenuChoices.GetComponent < EmptyObject_PlayerChoices> ()._Wep3, transform.position, Quaternion.identity);

			_Wep1.name = "Weapon1";
			_Wep2.name = "Weapon2";
			_Wep3.name = "Weapon3";

			_Wep1.transform.parent = _Inventory.transform;
			_Wep2.transform.parent = _Inventory.transform;
			_Wep3.transform.parent = _Inventory.transform;

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
				CmdAddArme("Weapon1",_PlayerMenuChoices.GetComponent < EmptyObject_PlayerChoices> ()._IdxWep1,_Weapons[_Wep1.GetComponent<Arme> ().id].cadence,_Weapons[_Wep1.GetComponent<Arme> ().id].degat, _Weapons[_Wep1.GetComponent<Arme> ().id].vitesse,_Weapons[_Wep1.GetComponent<Arme> ().id].range,_Weapons[_Wep1.GetComponent<Arme> ().id].nom);

			}
			else if(_Wep1.tag == "Spell"){
				_Wep1.GetComponent<Sort> ().cadence = _Spells [_Wep1.GetComponent<Sort> ().id].cadence;
				_Wep1.GetComponent<Sort> ().degat = _Spells[_Wep1.GetComponent<Sort> ().id].degat;
				_Wep1.GetComponent<Sort> ().vitesse = _Spells[_Wep1.GetComponent<Sort> ().id].vitesse;
				_Wep1.GetComponent<Sort> ().range = _Spells[_Wep1.GetComponent<Sort> ().id].range;
				_Wep1.GetComponent<Sort> ().nom = _Spells[_Wep1.GetComponent<Sort> ().id].nom;
				CmdAddSort("Weapon1",_PlayerMenuChoices.GetComponent < EmptyObject_PlayerChoices> ()._IdxWep1,_Spells[_Wep1.GetComponent<Sort> ().id].cadence,_Spells[_Wep1.GetComponent<Sort> ().id].degat, _Spells[_Wep1.GetComponent<Sort> ().id].vitesse,_Spells[_Wep1.GetComponent<Sort> ().id].range,_Spells[_Wep1.GetComponent<Sort> ().id].nom);

			}
			if(_Wep2.tag == "Weapon")
			{
				_Wep2.GetComponent<Arme> ().cadence = _Weapons[_Wep2.GetComponent<Arme> ().id].cadence;
				_Wep2.GetComponent<Arme> ().degat = _Weapons[_Wep2.GetComponent<Arme> ().id].degat;
				_Wep2.GetComponent<Arme> ().vitesse = _Weapons[_Wep2.GetComponent<Arme> ().id].vitesse;
				_Wep2.GetComponent<Arme> ().range = _Weapons[_Wep2.GetComponent<Arme> ().id].range;
				_Wep2.GetComponent<Arme> ().nom = _Weapons[_Wep2.GetComponent<Arme> ().id].nom;
				CmdAddArme("Weapon2",_PlayerMenuChoices.GetComponent < EmptyObject_PlayerChoices> ()._IdxWep2,_Weapons[_Wep2.GetComponent<Arme> ().id].cadence,_Weapons[_Wep2.GetComponent<Arme> ().id].degat, _Weapons[_Wep2.GetComponent<Arme> ().id].vitesse,_Weapons[_Wep2.GetComponent<Arme> ().id].range,_Weapons[_Wep2.GetComponent<Arme> ().id].nom);

			}
			else if(_Wep2.tag == "Spell"){
				_Wep2.GetComponent<Sort> ().cadence = _Spells[_Wep2.GetComponent<Sort> ().id].cadence;
				_Wep2.GetComponent<Sort> ().degat = _Spells[_Wep2.GetComponent<Sort> ().id].degat;
				_Wep2.GetComponent<Sort> ().vitesse = _Spells[_Wep2.GetComponent<Sort> ().id].vitesse;
				_Wep2.GetComponent<Sort> ().range = _Spells[_Wep2.GetComponent<Sort> ().id].range;
				_Wep2.GetComponent<Sort> ().nom = _Spells[_Wep2.GetComponent<Sort> ().id].nom;
				CmdAddSort("Weapon2",_PlayerMenuChoices.GetComponent < EmptyObject_PlayerChoices> ()._IdxWep2,_Spells[_Wep2.GetComponent<Sort> ().id].cadence,_Spells[_Wep2.GetComponent<Sort> ().id].degat, _Spells[_Wep2.GetComponent<Sort> ().id].vitesse,_Spells[_Wep2.GetComponent<Sort> ().id].range,_Spells[_Wep2.GetComponent<Sort> ().id].nom);

			}
			if(_Wep3.tag == "Weapon")
			{
				_Wep3.GetComponent<Arme> ().cadence = _Weapons[_Wep3.GetComponent<Arme> ().id].cadence;
				_Wep3.GetComponent<Arme> ().degat = _Weapons[_Wep3.GetComponent<Arme> ().id].degat;
				_Wep3.GetComponent<Arme> ().vitesse = _Weapons[_Wep3.GetComponent<Arme> ().id].vitesse;
				_Wep3.GetComponent<Arme> ().range = _Weapons[_Wep3.GetComponent<Arme> ().id].range;
				_Wep3.GetComponent<Arme> ().nom = _Weapons[_Wep3.GetComponent<Arme> ().id].nom;
				CmdAddArme("Weapon3",_PlayerMenuChoices.GetComponent < EmptyObject_PlayerChoices> ()._IdxWep3,_Weapons[_Wep3.GetComponent<Arme> ().id].cadence,_Weapons[_Wep3.GetComponent<Arme> ().id].degat, _Weapons[_Wep3.GetComponent<Arme> ().id].vitesse,_Weapons[_Wep3.GetComponent<Arme> ().id].range,_Weapons[_Wep3.GetComponent<Arme> ().id].nom);
			}
			else if(_Wep3.tag == "Spell"){
				_Wep3.GetComponent<Sort> ().cadence = _Spells[_Wep3.GetComponent<Sort> ().id].cadence;
				_Wep3.GetComponent<Sort> ().degat = _Spells[_Wep3.GetComponent<Sort> ().id].degat;
				_Wep3.GetComponent<Sort> ().vitesse = _Spells[_Wep3.GetComponent<Sort> ().id].vitesse;
				_Wep3.GetComponent<Sort> ().range = _Spells[_Wep3.GetComponent<Sort> ().id].range;
				_Wep3.GetComponent<Sort> ().nom = _Spells[_Wep3.GetComponent<Sort> ().id].nom;
				CmdAddSort("Weapon3",_PlayerMenuChoices.GetComponent < EmptyObject_PlayerChoices> ()._IdxWep3,_Spells[_Wep3.GetComponent<Sort> ().id].cadence,_Spells[_Wep3.GetComponent<Sort> ().id].degat, _Spells[_Wep3.GetComponent<Sort> ().id].vitesse,_Spells[_Wep3.GetComponent<Sort> ().id].range,_Spells[_Wep3.GetComponent<Sort> ().id].nom);
			}
		}
	}


	// Update is called once per frame
	void Update () {

	}

	[Command]
	void CmdInitInventaire() {
		Weapon w1 = GameObject.Find ("Weapon1").GetComponent<Weapon> ();
		if (w1 == null)
			return;
		Weapon w2 = GameObject.Find ("Weapon2").GetComponent<Weapon> ();
		Weapon w3 = GameObject.Find ("Weapon3").GetComponent<Weapon> ();

		if (w1.tag == "Weapon") {
			RpcInitArme ("Weapon1", w1.id_tabweapon, w1.cadence, w1.degat, w1.vitesse, w1.range, w1.nom);
		} else {
			RpcInitSort ("Weapon1", w1.id_tabweapon, w1.cadence, w1.degat, w1.vitesse, w1.range, w1.nom);
		}

		if (w2.tag == "Weapon") {
			RpcInitArme ("Weapon2", w2.id_tabweapon, w2.cadence, w2.degat, w2.vitesse, w2.range, w2.nom);
		} else {
			RpcInitSort ("Weapon2", w2.id_tabweapon, w2.cadence, w2.degat, w2.vitesse, w2.range, w2.nom);
		}

		if (w3.tag == "Weapon") {
			RpcInitArme ("Weapon3", w3.id_tabweapon, w3.cadence, w3.degat, w3.vitesse, w3.range, w3.nom);
		} else {
			RpcInitSort ("Weapon3", w3.id_tabweapon, w3.cadence, w3.degat, w3.vitesse, w3.range, w3.nom);
		}
	}

	[ClientRpc]
	void RpcInitArme(string name,int id,float cadence,int degat,float vitesse,int range,string nom) {
		if (!isLocalPlayer)
			return;
		
		GameObject newArme = Instantiate (GameObject.Find ("TabPrefab").GetComponent<TabPrefabs> ().tab [id],transform.position, Quaternion.identity);
		newArme.name = name;
		newArme.transform.parent=this.transform.FindChild ("Camera Pivot").transform.FindChild ("Inventory").gameObject.transform;
		newArme.GetComponent<Arme> ().cadence = cadence;
		newArme.GetComponent<Arme> ().degat = degat;
		newArme.GetComponent<Arme> ().vitesse = vitesse;
		newArme.GetComponent<Arme> ().range = range;
		newArme.GetComponent<Arme> ().nom = nom;
		newArme.GetComponent<Arme> ().id_tabweapon = id;
	}

	[ClientRpc]
	void RpcInitSort(string name,int id,float cadence,int degat,float vitesse,int range,string nom){
		if (!isLocalPlayer)
			return;
		
		GameObject newArme = Instantiate (GameObject.Find ("TabPrefab").GetComponent<TabPrefabs> ().tab [id],transform.position, Quaternion.identity);
		newArme.name = name;
		newArme.transform.parent=this.transform.FindChild ("Camera Pivot").transform.FindChild ("Inventory").gameObject.transform;
		newArme.GetComponent<Sort> ().cadence = cadence;
		newArme.GetComponent<Sort> ().degat = degat;
		newArme.GetComponent<Sort> ().vitesse = vitesse;
		newArme.GetComponent<Sort> ().range = range;
		newArme.GetComponent<Sort> ().nom = nom;
		newArme.GetComponent<Sort> ().id_tabweapon = id;
	}

	[Command]
	void CmdAddArme(string name,int id,float cadence,int degat,float vitesse,int range,string nom){
		GameObject newArme = Instantiate (GameObject.Find ("TabPrefab").GetComponent<TabPrefabs> ().tab [id],transform.position, Quaternion.identity);
		newArme.name = name;
		newArme.transform.parent=this.transform.FindChild ("Camera Pivot").transform.FindChild ("Inventory").gameObject.transform;
		newArme.GetComponent<Arme> ().cadence = cadence;
		newArme.GetComponent<Arme> ().degat = degat;
		newArme.GetComponent<Arme> ().vitesse = vitesse;
		newArme.GetComponent<Arme> ().range = range;
		newArme.GetComponent<Arme> ().nom = nom;
		newArme.GetComponent<Arme> ().id_tabweapon = id;

		RpcAddArme (name, id, cadence, degat, vitesse, range, nom);
	}

	[Command]
	void CmdAddSort(string name,int id,float cadence,int degat,float vitesse,int range,string nom){
		GameObject newArme = Instantiate (GameObject.Find ("TabPrefab").GetComponent<TabPrefabs> ().tab [id],transform.position, Quaternion.identity);
		newArme.name = name;
		newArme.transform.parent=this.transform.FindChild ("Camera Pivot").transform.FindChild ("Inventory").gameObject.transform;
		newArme.GetComponent<Sort> ().cadence = cadence;
		newArme.GetComponent<Sort> ().degat = degat;
		newArme.GetComponent<Sort> ().vitesse = vitesse;
		newArme.GetComponent<Sort> ().range = range;
		newArme.GetComponent<Sort> ().nom = nom;
		newArme.GetComponent<Sort> ().id_tabweapon = id;

		RpcAddSort (name, id, cadence, degat, vitesse, range, nom);
	}

	[ClientRpc]
	void RpcAddArme(string name,int id,float cadence,int degat,float vitesse,int range,string nom){
		if (isLocalPlayer)
			return;
		GameObject newArme = Instantiate (GameObject.Find ("TabPrefab").GetComponent<TabPrefabs> ().tab [id],transform.position, Quaternion.identity);
		newArme.name = name;
		newArme.transform.parent=this.transform.FindChild ("Camera Pivot").transform.FindChild ("Inventory").gameObject.transform;
		newArme.GetComponent<Arme> ().cadence = cadence;
		newArme.GetComponent<Arme> ().degat = degat;
		newArme.GetComponent<Arme> ().vitesse = vitesse;
		newArme.GetComponent<Arme> ().range = range;
		newArme.GetComponent<Arme> ().nom = nom;
		newArme.GetComponent<Arme> ().id_tabweapon = id;
	}

	[ClientRpc]
	void RpcAddSort(string name,int id,float cadence,int degat,float vitesse,int range,string nom){
		if (isLocalPlayer)
			return;
		GameObject newArme = Instantiate (GameObject.Find ("TabPrefab").GetComponent<TabPrefabs> ().tab [id],transform.position, Quaternion.identity);
		newArme.name = name;
		newArme.transform.parent=this.transform.FindChild ("Camera Pivot").transform.FindChild ("Inventory").gameObject.transform;
		newArme.GetComponent<Sort> ().cadence = cadence;
		newArme.GetComponent<Sort> ().degat = degat;
		newArme.GetComponent<Sort> ().vitesse = vitesse;
		newArme.GetComponent<Sort> ().range = range;
		newArme.GetComponent<Sort> ().nom = nom;
		newArme.GetComponent<Sort> ().id_tabweapon = id;
	}
}
