using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {
	// MACROS
	private const float CAMERA_X_FACTOR = 4.0f;		// camera sensibility (along X axis)
	private const float CAMERA_Y_FACTOR = 3.0f;		// camera sensibility (along Y axis)
	private const float DEFAULT_SPEED = 3.0f;		// running speed
	private const float STRAFE_FACTOR = 0.7f;		// speed factor while strafing
	
	// Public variables
	public GameObject _cameraPivot;
	public bool _invertYAxis;
	public bool _InGameMenuIsDisplayed = false;
	
	// Private variables
	private float _forwardRunningSpeed = 0;		// Current forward running speed (can be negative for backward)
	private float _strafeSpeed = 0;				// Current strafing speed (negative value means left, positive means right)
	private float _camRotX = 0.0f;				// Current camera rotation around X

	// Private values stocking vertical and horizontal input for camera
	private float _XInput;
	private float _YInput;

	// ----------------------------------------------------------------------------------------------------

	/*public override void OnStartLocalPlayer() {
		GetComponent<CameraManager> ().enabled = true;
		GetComponent<PlayerInput> ().enabled = true;
		GetComponent<SkinChoice> ().enabled = true;
		SkinChoice SC = GetComponent<SkinChoice> ();
		for (int i = 0; i < 2; i++) {
			SC._skins [i].SetActive (false);
		}

		base.OnStartLocalPlayer ();
	}*/

	// Use this for initialization
	void Start () {
		// Hide cursor
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;

		// Default Y camera axis is not inverted
		_invertYAxis = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!_InGameMenuIsDisplayed) {
			MoveCamera ();
			MovePlayer ();
		}
	}

	// ----------------------------------------------------------------------------------------------------

	/**
	 * MoveCamera
	 * Move the camera along X & Y axis, using the inputs given by PlayerInput.
	 **/
	private void MoveCamera () {
		float invertFactor;

		// Update current camera rotation around X to cap it
		_camRotX += _YInput * CAMERA_Y_FACTOR;

		// If the rotation exceeds 90° (up or down), ignore the rest.
		if (_camRotX < -90f) {
			_camRotX = -90f;
			return;
		}
		if (_camRotX > 90f) {
			_camRotX = 90f;
			return;
		}

		// Rotate player around Y axis (along X) with horizontal input
		transform.RotateAround(transform.position, transform.up, 
			CAMERA_X_FACTOR * _XInput);

		if (_invertYAxis)
			invertFactor = -1.0f;
		else
			invertFactor = 1.0f;

		// Rotate camera pivot (and NOT player) around X axis (along Y) with vertical mouse movements
		_cameraPivot.transform.RotateAround (_cameraPivot.transform.position, _cameraPivot.transform.right,
			- _YInput * CAMERA_Y_FACTOR * invertFactor);
	}


	/**
	 * MovePlayer
	 * Move player along forward and right axis, using parameters updated by PlayerInput via
	 * UpdateForwardSpeed & UpdateStrafeSpeed methods.
	 **/
	void MovePlayer () {
		transform.position += 
			transform.forward * _forwardRunningSpeed * Time.deltaTime
			+ transform.right * _strafeSpeed * Time.deltaTime;
			
		//rigidbody.velocity = new Vector3(_forwardRunningSpeed, 0.0f, _strafeSpeed);
	}

	/**
	 * UpdateCameraXY
	 * Update the X and Y axis input
	 * @param X_val : X axis input
	 * @param Y_val : Y axis input
	 **/
	[Command]
	public void CmdUpdateCameraXY (float X_val, float Y_val) {
		_XInput = X_val;
		_YInput = Y_val;
		RpcUpdateCameraXY (X_val, Y_val);
	}

	[ClientRpc]
	void RpcUpdateCameraXY (float X_val, float Y_val) {
		_XInput = X_val;
		_YInput = Y_val;
	}

	/**
	 * UpdateForwardSpeed
	 * Update the current running speed along forward vector (called via PlayerInput).
	 * @param d : whether player should run backward (-1), forward (1) or not run at all (0).
	 **/
	[Command]
	public void CmdUpdateForwardSpeed (int d) {
		d = Mathf.Clamp (d, -1, 1);
		RpcUpdateForwardSpeed (d);
		_forwardRunningSpeed = d * DEFAULT_SPEED;
		//Debug.Log (_forwardRunningSpeed);
	}

	[ClientRpc]
	void RpcUpdateForwardSpeed (int d) {
		_forwardRunningSpeed = d * DEFAULT_SPEED;
	}

	/**
	 * UpdateStrafeSpeed
	 * Update the current strafe speed along right vector (called via PlayerInput).
	 * @param d : whether player should strafe left (-1), right (1) or not strafe at all (0).
	 **/
	[Command]
	public void CmdUpdateStrafeSpeed (int d) {
		d = Mathf.Clamp (d, -1, 1);
		RpcUpdateStrafeSpeed (d);
		_strafeSpeed = d * STRAFE_FACTOR * DEFAULT_SPEED;
		//Debug.Log (_strafeSpeed);
	}

	[ClientRpc]
	void RpcUpdateStrafeSpeed (int d) {
		_strafeSpeed = d * STRAFE_FACTOR * DEFAULT_SPEED;
	}
}
