<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_WeaponsChoice : MonoBehaviour {

	public GameObject _Weapon1;
	public GameObject _Weapon2;
	public GameObject _Weapon3;

	public int Weapon1_index = 0;
	public int Weapon2_index = 0;
	public int Weapon3_index = 0;

	public static int numberOfAvaibleWeapons = 6;
	public GameObject[] _Weapons = new GameObject[numberOfAvaibleWeapons];

	// Use this for initialization
	void Start () {
		_Weapon1.GetComponent<Image> ().sprite = _Weapons [Weapon1_index].GetComponent<WeaponIconReferencing>()._WeaponSprite;
		_Weapon2.GetComponent<Image> ().sprite = _Weapons [Weapon1_index].GetComponent<WeaponIconReferencing>()._WeaponSprite;
		_Weapon3.GetComponent<Image> ().sprite =_Weapons [Weapon1_index].GetComponent<WeaponIconReferencing>()._WeaponSprite;

	}

	// Update is called once per frame
	void Update () {

	}

	public void OnWep1UpClicked(){
		if (Weapon1_index < numberOfAvaibleWeapons - 1) {
			Weapon1_index++;
		} else {
			Weapon1_index = 0;
		}
		_Weapon1.GetComponent<Image> ().sprite = _Weapons [Weapon1_index].GetComponent<WeaponIconReferencing>()._WeaponSprite;
	}

	public void OnWep1DownClicked(){
		if (Weapon1_index > 0) {
			Weapon1_index--;
		} else {
			Weapon1_index = numberOfAvaibleWeapons - 1;
		}
		_Weapon1.GetComponent<Image> ().sprite = _Weapons [Weapon1_index].GetComponent<WeaponIconReferencing>()._WeaponSprite;
	}

	public void OnWep2UpClicked(){
		if (Weapon2_index < numberOfAvaibleWeapons - 1) {
			Weapon2_index++;
		} else {
			Weapon2_index = 0;
		}
		_Weapon2.GetComponent<Image> ().sprite = _Weapons [Weapon2_index].GetComponent<WeaponIconReferencing>()._WeaponSprite;
	}

	public void OnWep2DownClicked(){
		if (Weapon2_index > 0) {
			Weapon2_index--;
		} else {
			Weapon2_index = numberOfAvaibleWeapons - 1;
		}
		_Weapon2.GetComponent<Image> ().sprite = _Weapons [Weapon2_index].GetComponent<WeaponIconReferencing>()._WeaponSprite;
	}

	public void OnWep3UpClicked(){
		if (Weapon3_index < numberOfAvaibleWeapons - 1) {
			Weapon3_index++;
		} else {
			Weapon3_index = 0;
		}
		_Weapon3.GetComponent<Image> ().sprite = _Weapons [Weapon3_index].GetComponent<WeaponIconReferencing>()._WeaponSprite;
	}

	public void OnWep3DownClicked(){
		if (Weapon3_index > 0) {
			Weapon3_index--;
		} else {
			Weapon3_index = numberOfAvaibleWeapons - 1;
		}
		_Weapon3.GetComponent<Image> ().sprite = _Weapons [Weapon3_index].GetComponent<WeaponIconReferencing>()._WeaponSprite;
	}
}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_WeaponsChoice : MonoBehaviour {

	public GameObject _Weapon1;
	public GameObject _Weapon2;
	public GameObject _Weapon3;

	public int Weapon1_index = 0;
	public int Weapon2_index = 0;
	public int Weapon3_index = 0;

	public static int numberOfAvaibleWeapons = 6;
	public GameObject[] _Weapons = new GameObject[numberOfAvaibleWeapons];

	// Use this for initialization
	void Start () {
		_Weapon1.GetComponent<Image> ().sprite = _Weapons [Weapon1_index].GetComponent<WeaponIconReferencing>()._WeaponSprite;
		_Weapon2.GetComponent<Image> ().sprite = _Weapons [Weapon1_index].GetComponent<WeaponIconReferencing>()._WeaponSprite;
		_Weapon3.GetComponent<Image> ().sprite =_Weapons [Weapon1_index].GetComponent<WeaponIconReferencing>()._WeaponSprite;

	}

	// Update is called once per frame
	void Update () {

	}

	public void OnWep1UpClicked(){
		if (Weapon1_index < numberOfAvaibleWeapons - 1) {
			Weapon1_index++;
		} else {
			Weapon1_index = 0;
		}
		_Weapon1.GetComponent<Image> ().sprite = _Weapons [Weapon1_index].GetComponent<WeaponIconReferencing>()._WeaponSprite;
	}

	public void OnWep1DownClicked(){
		if (Weapon1_index > 0) {
			Weapon1_index--;
		} else {
			Weapon1_index = numberOfAvaibleWeapons - 1;
		}
		_Weapon1.GetComponent<Image> ().sprite = _Weapons [Weapon1_index].GetComponent<WeaponIconReferencing>()._WeaponSprite;
	}

	public void OnWep2UpClicked(){
		if (Weapon2_index < numberOfAvaibleWeapons - 1) {
			Weapon2_index++;
		} else {
			Weapon2_index = 0;
		}
		_Weapon2.GetComponent<Image> ().sprite = _Weapons [Weapon2_index].GetComponent<WeaponIconReferencing>()._WeaponSprite;
	}

	public void OnWep2DownClicked(){
		if (Weapon2_index > 0) {
			Weapon2_index--;
		} else {
			Weapon2_index = numberOfAvaibleWeapons - 1;
		}
		_Weapon2.GetComponent<Image> ().sprite = _Weapons [Weapon2_index].GetComponent<WeaponIconReferencing>()._WeaponSprite;
	}

	public void OnWep3UpClicked(){
		if (Weapon3_index < numberOfAvaibleWeapons - 1) {
			Weapon3_index++;
		} else {
			Weapon3_index = 0;
		}
		_Weapon3.GetComponent<Image> ().sprite = _Weapons [Weapon3_index].GetComponent<WeaponIconReferencing>()._WeaponSprite;
	}

	public void OnWep3DownClicked(){
		if (Weapon3_index > 0) {
			Weapon3_index--;
		} else {
			Weapon3_index = numberOfAvaibleWeapons - 1;
		}
		_Weapon3.GetComponent<Image> ().sprite = _Weapons [Weapon3_index].GetComponent<WeaponIconReferencing>()._WeaponSprite;
	}
}
>>>>>>> origin/master
