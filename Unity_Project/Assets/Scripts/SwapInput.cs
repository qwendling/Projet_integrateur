﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SwapInput : NetworkBehaviour {
	public GameObject _swapEngine;
	
	public PlayerController _player;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		/*if(!_player.isLocalPlayer)
			return;
		*/
		// For some reason, sending message "swap" with 0 as argument won't work,
		//	because 0 is interpreted as null (╯°□°）╯︵ ┻━┻
		int i = 0;
		if(Input.GetKeyDown (KeyCode.Alpha1)){
			_swapEngine.SendMessage("CmdSwap", i);
		}
		if(Input.GetKeyDown (KeyCode.Alpha2)){
			_swapEngine.SendMessage("CmdSwap", i+1);
		}
		if(Input.GetKeyDown (KeyCode.Alpha3)){
			_swapEngine.SendMessage("CmdSwap", i+2);
		}
		
	}
}
