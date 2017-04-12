using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ToolSwapTest : NetworkBehaviour {
	// Maximum weapon/spell equiped
	public static int INVENTORY_SIZE = 3;

	//public GameObject _inventoryGameObject;
	public GameObject[] _inventory = new GameObject[INVENTORY_SIZE];
	public GameObject _activeItem;
	public GameObject _PlayerMenuChoices;


	private int _currentItem = 0;
	private int CurrentItem {
		get { return _currentItem; }
		set { _currentItem = value; }
	}

	// Use this for initialization
	void Start () {

		while (_PlayerMenuChoices == null) {
			_PlayerMenuChoices = GameObject.Find ("PlayerChoices");
		}



		for (int i = 1; i < INVENTORY_SIZE; i++) {
			if(i == CurrentItem) {
				_inventory[i].SetActive(true);
				_activeItem = _inventory[i];
			} else {
				_inventory[i].SetActive(false);
			}
		}

	}

	// Update is called once per frame
	void Update () {
		if (_inventory [0] == null) {
			_inventory [0] = GameObject.Find ("Weapon1");
			_inventory[0].SetActive(false);
		}
		if (_inventory [1] == null) {
			_inventory [1] = GameObject.Find ("Weapon2");
			_inventory[1].SetActive(false);
		}
		if (_inventory [2] == null) {
			_inventory [2] = GameObject.Find ("Weapon3");
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
			_inventory[CurrentItem].SetActive(false);
			CurrentItem = i;
			_inventory[CurrentItem].SetActive(true);
			_activeItem = _inventory[CurrentItem];
		}
	}

	[ClientRpc]
	void RpcSwap (int i) {
		_inventory[CurrentItem].SetActive(false);
		CurrentItem = i;
		_inventory[CurrentItem].SetActive(true);
		_activeItem = _inventory[CurrentItem];
	}
}
