﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerInput : NetworkBehaviour {
	public GameObject _player;

	private PlayerController _controller;

	// Use this for initialization
	void Start () {
		_controller = _player.GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		_controller.CamX = Input.GetAxis("Mouse X");
		_controller.CamY = Input.GetAxis("Mouse Y");

		int forward, right;

		if (Input.GetKey (KeyCode.Z)) {
			forward = 1;
		} else if (Input.GetKey (KeyCode.S)) {
			forward = -1;
		} else {
			forward = 0;
		}

		_player.SendMessage ("CmdUpdateForwardSpeed", forward);

		if (Input.GetKey (KeyCode.D)) {
			right = 1;
		} else if (Input.GetKey (KeyCode.Q)) {
			right = -1;
		} else {
			right = 0;
		}

		_player.SendMessage ("CmdUpdateStrafeSpeed", right);
	}
}
