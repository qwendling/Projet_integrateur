using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SkinChoice : NetworkBehaviour {
	public static int NBR_OF_SKINS = 2;

	public GameObject[] _skins = new GameObject[NBR_OF_SKINS];
	public GameObject _activeSkin;

	private int _currentSkin = 0;
	private int CurrentSkin {
		get { return _currentSkin; }
		set { _currentSkin = value; }
	}

	// Use this for initialization
	void Start () {
		for (int i = 1; i < NBR_OF_SKINS; i++) {
			if(i == CurrentSkin) {
				_skins[i].SetActive(true);
			} else {
				_skins[i].SetActive(false);
			}
		}
		_activeSkin = _skins[CurrentSkin];

		if (isLocalPlayer) {
			CmdChooseSkin (0);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	[Command]
	void CmdChooseSkin(int i) {
		i = Mathf.Clamp (i, 0, NBR_OF_SKINS);
		if(i != CurrentSkin){
			RpcChooseSkin (i);
			_skins[CurrentSkin].SetActive(false);
			CurrentSkin = i;
			_skins[CurrentSkin].SetActive(true);
			_activeSkin = _skins[CurrentSkin];
		}
	}

	[ClientRpc]
	void RpcChooseSkin(int i) {
		_skins[CurrentSkin].SetActive(false);
		CurrentSkin = i;
		_skins[CurrentSkin].SetActive(false);
		_activeSkin = _skins[CurrentSkin];
	}
}
