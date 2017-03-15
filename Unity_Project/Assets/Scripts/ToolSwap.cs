using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ToolSwap : NetworkBehaviour {
	// Maximum weapon/spell equiped
	public static int INVENTORY_SIZE = 3;
	
	public GameObject[] _inventory = new GameObject[INVENTORY_SIZE];
	public GameObject _activeItem;
	
	private int _currentItem = 0;
	private int CurrentItem {
		get { return _currentItem; }
		set { _currentItem = value; }
	}

	// Use this for initialization
	void Start () {
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
		
	}
	
	void Swap (int i) {
		i = Mathf.Clamp (i, 0, INVENTORY_SIZE);
		if(i != CurrentItem){
			_inventory[CurrentItem].SetActive(false);
			CurrentItem = i;
			_inventory[CurrentItem].SetActive(true);
			_activeItem = _inventory[CurrentItem];
		}
	}
}
