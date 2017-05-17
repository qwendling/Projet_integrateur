using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ToolSwap : NetworkBehaviour {
	// Maximum weapon/spell equiped
	public static int INVENTORY_SIZE = 3;

	//public GameObject _inventoryGameObject;
	public GameObject[] _inventory = new GameObject[INVENTORY_SIZE];
	public GameObject _activeItem;
	public GameObject _PlayerMenuChoices;

	[SyncVar]
	private int _currentItem = 1;
	private int CurrentItem {
		get { return _currentItem; }
		set { _currentItem = value; }
	}

	// Use this for initialization
	void Start () {
		
		/*while (_PlayerMenuChoices == null) {
			_PlayerMenuChoices = GameObject.Find ("PlayerChoices");
		}*/
		/*
		for (int i = 1; i < INVENTORY_SIZE; i++) {
			if(i == CurrentItem) {
				_inventory[i].SetActive(true);
			} else {
				_inventory[i].SetActive(false);
			}
		}
		_activeItem = _inventory[CurrentItem];*/

		Animator anim = gameObject.GetComponent<PlayerInput> ().anim;
		if (_activeItem != null) {
			AnimArme a = _activeItem.GetComponent<Weapon> ().Anim;
			if (a == AnimArme.ak) {
				anim.SetBool ("ak", true);
				anim.SetBool ("weapon", false);
				anim.SetBool ("ball", false);
			} else if (a == AnimArme.ball) {
				anim.SetBool ("ball", true);
				anim.SetBool ("weapon", false);
				anim.SetBool ("ak", false);
			} else if (a == AnimArme.weapon) {
				anim.SetBool ("weapon", true);
				anim.SetBool ("ak", false);
				anim.SetBool ("ball", false);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (_inventory [0] == null) {
			Transform t = transform.GetChild (0).GetChild (1).GetChild (0);
			if(t != null) {
				_inventory [0] = t.gameObject;
			}
			if (_inventory [0] == null)
				return;
			_inventory[0].SetActive(false);
		}
		if (_inventory [1] == null) {
			Transform t = transform.GetChild (0).GetChild (1).GetChild (1);
			if(t != null) {
				_inventory [1] = t.gameObject;
			}
			if (_inventory [1] == null)
				return;
			_inventory[1].SetActive(false);
		}
		if (_inventory [2] == null) {
			Transform t = transform.GetChild (0).GetChild (1).GetChild (2);
			if(t != null) {
				_inventory [2] = t.gameObject;
			}
			if (_inventory [2] == null)
				return;
			_inventory[2].SetActive(false);
		}
		if (_activeItem == null) {
			_activeItem = _inventory [_currentItem];
			_inventory[_currentItem].SetActive(true);
		}
	}
	
	[Command]
	public void CmdSwap (int i) {		
		i = Mathf.Clamp (i, 0, INVENTORY_SIZE);
		if(i != CurrentItem){
			RpcSwap (i);
			CurrentItem = i;
			/*_inventory[CurrentItem].SetActive(false);
			_inventory[CurrentItem].SetActive(true);*/
			_activeItem = _inventory[CurrentItem];
		}
	}

	[ClientRpc]
	void RpcSwap (int i) {
		_inventory[CurrentItem].SetActive(false);
		CurrentItem = i;
		_inventory[CurrentItem].SetActive(true);
		_activeItem = _inventory[CurrentItem];
		Animator anim = gameObject.GetComponent<PlayerInput> ().anim;
		AnimArme a = _activeItem.GetComponent<Weapon> ().Anim;
		if (a == AnimArme.ak) {
			anim.SetBool("ak", true);
			anim.SetBool("weapon", false);
			anim.SetBool("ball", false);
		} else if (a == AnimArme.ball) {
			anim.SetBool("ball", true);
			anim.SetBool("weapon", false);
			anim.SetBool("ak", false);
		} else if (a == AnimArme.weapon) {
			anim.SetBool("weapon", true);
			anim.SetBool("ak", false);
			anim.SetBool("ball", false);
		}
	}
}
