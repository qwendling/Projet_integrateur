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


	private int _currentItem = 0;
	private int CurrentItem {
		get { return _currentItem; }
		set { _currentItem = value; }
	}

	// Use this for initialization
	void Start () {
		
		/*while (_PlayerMenuChoices == null) {
			_PlayerMenuChoices = GameObject.Find ("PlayerChoices");
		}*/

		for (int i = 1; i < INVENTORY_SIZE; i++) {
			if(i == CurrentItem) {
				_inventory[i].SetActive(true);
			} else {
				_inventory[i].SetActive(false);
			}
		}
		_activeItem = _inventory[CurrentItem];
	}
	
	// Update is called once per frame
	void Update () {
		if (_inventory [0] == null) {
			_inventory [0] = GameObject.Find ("Weapon1");
		}
		if (_inventory [1] == null) {
			_inventory [1] = GameObject.Find ("Weapon2");
		}
		if (_inventory [2] == null) {
			_inventory [2] = GameObject.Find ("Weapon3");
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
