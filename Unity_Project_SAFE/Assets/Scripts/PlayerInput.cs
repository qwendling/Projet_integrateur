using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerInput : NetworkBehaviour {
	public GameObject _player;

	private PlayerController _controller;
	private PlayerHealth _health;
	private ToolSwap _swapper;
	private CanShoot _shoot;

	// Use this for initialization
	void Start () {
		_controller = _player.GetComponent<PlayerController> ();
		_health = _player.GetComponent<PlayerHealth> ();
		_swapper = _player.GetComponent<ToolSwap> ();
		_shoot = _player.GetComponent<CanShoot> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isServer) {
			// MDR
		}

		if (Input.GetKeyDown (KeyCode.T)) {
			Time.timeScale = 0;
		}

		if(!isLocalPlayer)
			return;

		// TEST HEALTH

		if (Input.GetKeyDown (KeyCode.K)) {
			CmdTestHealth ();
		}

		// SHOOT COMMAND

		if (Input.GetButtonDown("Fire1"))
		{
			_shoot.CmdFire ();
		}

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

	[Command] 
	void CmdTestHealth() {
		_health.TakeDamage (100);
	}
}
