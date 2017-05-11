using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SkinChoice : NetworkBehaviour {
	//public static int NBR_OF_SKINS = 2;
	public GameObject _PlayerMenuChoices;
	public GameObject _Skin;
	public string _PlayerName;

	//private int _activeSkin = 0;
	//private bool _uptodate = false;

	// Use this for initialization
	void Start () {
		if (isLocalPlayer) {
			_Skin.SetActive (false);

			/*while (_PlayerMenuChoices == null) {
				_PlayerMenuChoices = GameObject.Find ("PlayerChoices");
			}*/
			//_PlayerName = _PlayerMenuChoices.GetComponent<EmptyObject_PlayerChoices> ()._Name;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
