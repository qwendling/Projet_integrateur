using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerInput : NetworkBehaviour {
	public GameObject _player;

	private PlayerController _controller;
	private ToolSwap _swapper;

	// Use this for initialization
	void Start () {
		_controller = _player.GetComponent<PlayerController> ();
		_swapper = _player.GetComponent<ToolSwap> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isServer) {
			// MDR
		}

		if(!isLocalPlayer)
			return;

		// CAMERA CONTROL

		_controller.CmdUpdateCameraXY (Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

		// MOVEMENT CONTROL

		int forward, right;

		if (Input.GetKey (KeyCode.Z)) {
			forward = 1;
		} else if (Input.GetKey (KeyCode.S)) {
			forward = -1;
		} else {
			forward = 0;
		}

		_controller.CmdUpdateForwardSpeed (forward);

		if (Input.GetKey (KeyCode.D)) {
			right = 1;
		} else if (Input.GetKey (KeyCode.Q)) {
			right = -1;
		} else {
			right = 0;
		}

		_controller.CmdUpdateStrafeSpeed (right);

		// WEAPON SWAP

		// For some reason, sending message "swap" with 0 as argument won't work,
		// because 0 is interpreted as null (╯°□°）╯︵ ┻━┻
		// int i = 0;
		if(Input.GetKeyDown (KeyCode.Alpha1)){
			_swapper.CmdSwap (0);
		}
		if(Input.GetKeyDown (KeyCode.Alpha2)){
			_swapper.CmdSwap (1);
		}
		if(Input.GetKeyDown (KeyCode.Alpha3)){
			_swapper.CmdSwap (2);
		}
	}
}
