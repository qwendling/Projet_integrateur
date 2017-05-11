using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using GameMessages;
using System.Net.Sockets;
using System.Net;

public class PlayerInput : NetworkBehaviour {
	public GameObject _player;

	private PlayerController _controller;
	private PlayerHealth _health;
	private ToolSwap _swapper;
	private CanShoot _shoot;
	private PlayerOverHeat _POH;

	private bool _isOverheat = false;

	private float timebetweenShot;
	private double _timeShot;

	public int commande;

	private float _heatTimer;

	// Use this for initialization
	void Start () {		
		_controller = _player.GetComponent<PlayerController> ();
		_health = _player.GetComponent<PlayerHealth> ();
		_swapper = _player.GetComponent<ToolSwap> ();
		_shoot = _player.GetComponent<CanShoot> ();
		_POH = gameObject.GetComponent<PlayerOverHeat> ();

		_timeShot = -1.0;
	}

	// Update is called once per frame
	void Update () {
		if (isServer) {
			RpcOnOverheat ();
		}

		if(!isLocalPlayer)
			return;
		
		if (HeatTimerFinished ()) {
			_isOverheat = false;
		}

		timebetweenShot = 1/_swapper._activeItem.GetComponent<Weapon>().cadence;
		_timeShot -= 1.0 * Time.deltaTime;

		// SHOOT COMMAND

		if (Input.GetButton("Fire1") || (commande == 120))
		{
			// Si le delais de la cadence est passe
			if (!_isOverheat && _timeShot <= 0.0) {
				_timeShot = timebetweenShot;
				_shoot.CmdFire ();
				_POH.CmdHeat();
			}
		}

		// CAMERA CONTROL

		_controller.CmdUpdateCameraXY (Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
		/*
		if ( (commande == 710 ) )// up
				_controller.CmdUpdateCameraXY ((float)0.0, (float)0.40);

		if ( (commande == 810 ) ) // down
				_controller.CmdUpdateCameraXY ((float)0.0, (float)-0.40);

		if ( (commande == 310 ) )// gauche
				_controller.CmdUpdateCameraXY ((float)-0.40, (float)0.00);

		if ( (commande == 410 ) ) // droite
				_controller.CmdUpdateCameraXY ((float)0.40, (float)0.00);
*/
		// MOVEMENT CONTROL

		int forward, right;

		if (Input.GetKey (KeyCode.Z) || (commande == 110 ) ) {
			forward = 1;
		} else if (Input.GetKey (KeyCode.S)) {
			forward = -1;
		} else {
			forward = 0;
		}

		_controller.CmdUpdateForwardSpeed (forward);

		if (Input.GetKey (KeyCode.D) || (commande == 610 )) {
			right = 1;
		} else if (Input.GetKey (KeyCode.Q) || (commande == 510 ) ) {
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
			timebetweenShot = _swapper._activeItem.GetComponent<Weapon>().cadence;
		}
		if(Input.GetKeyDown (KeyCode.Alpha2) || (commande == 999 ) ){
			_swapper.CmdSwap (1);
			timebetweenShot = _swapper._activeItem.GetComponent<Weapon>().cadence;
		}
		if(Input.GetKeyDown (KeyCode.Alpha3)){
			_swapper.CmdSwap (2);
			timebetweenShot = _swapper._activeItem.GetComponent<Weapon>().cadence;
		}
	}

	// Run the timer, return true if timer has ended
	bool HeatTimerFinished () {
		_heatTimer -= 1.0f * Time.deltaTime;
		return (_heatTimer <= 0);
	}

	// Start/Refresh the timer
	void StartHeatTimer () {
		_heatTimer = PlayerOverHeat.HEAT_COOLDOWN;
	}

	[ClientRpc]
	void RpcOnOverheat() {
		if (!isLocalPlayer)
			return;
		
		if (gameObject.GetComponent<PlayerOverHeat> ().currentHeat >= PlayerOverHeat.MAX_HEAT) {
			_isOverheat = true;
			StartHeatTimer ();
		}
	}
}
