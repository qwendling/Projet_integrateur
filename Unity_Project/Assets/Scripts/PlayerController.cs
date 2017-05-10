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
	private const float MS_BOOST_DURATION = 5.0f;	// in seconds
	
	// Public variables

	public GameObject _cameraPivot;
	public bool _invertYAxis;
	public bool _InGameMenuIsDisplayed = false;
	
	// Private variables
	private float _acceleration = 1.0f;			// Current acceleration factor
	private float _forwardRunningSpeed = 0.0f;	// Current forward running speed (can be negative for backward)
	private float _strafeSpeed = 0.0f;			// Current strafing speed (negative value means left, positive means right)

	[SyncVar]
	private float _camRotX = 0.0f;				// Current camera rotation around X
	private float _msBoostTimer;
	private bool _msBoostRunning = false;

	// Private values stocking vertical and horizontal input for camera
	private float _XInput;

	private float _YInput;

	// ----------------------------------------------------------------------------------------------------

	// Use this for initialization
	void Start () {
		// Hide cursor
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;

		// Default Y camera axis is not inverted
		_invertYAxis = false;
		_cameraPivot.transform.RotateAround (_cameraPivot.transform.position, _cameraPivot.transform.right,
			- _camRotX );
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!isLocalPlayer)
			return;
		
		if (!_InGameMenuIsDisplayed) {
			
		}

		if (_msBoostRunning && TimerFinished()) {
			_acceleration = 1.0f;
			_msBoostRunning = false;
		}

	}

	// ----------------------------------------------------------------------------------------------------

	// Run the timer, return true if timer has ended
	bool TimerFinished () {
		_msBoostTimer -= 1.0f * Time.deltaTime;
		return (_msBoostTimer <= 0);
	}

	// Start/Refresh the timer
	void StartTimer () {
		_msBoostTimer = MS_BOOST_DURATION;
		_msBoostRunning = true;
	}

	[ClientRpc]
	public void RpcBoostSpeed(float acc_factor) {
		_acceleration = acc_factor;
		StartTimer ();
	}

	// ----------------------------------------------------------------------------------------------------

	/**
	 * MoveCamera
	 * Move the camera along X & Y axis, using the inputs given by PlayerInput.
	 **/
	private void MoveCamera () {
		








	}


	/**
	 * MovePlayer
	 * Move player along forward and right axis, using parameters updated by PlayerInput via
	 * UpdateForwardSpeed & UpdateStrafeSpeed methods.
	 **/
	void MovePlayer () {
		transform.position += 
			transform.forward * _forwardRunningSpeed * _acceleration * Time.deltaTime
			+ transform.right * _strafeSpeed * _acceleration * Time.deltaTime;
		
	}

	// ----------------------------------------------------------------------------------------------------

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
		float invertFactor;
		if (_invertYAxis)
			invertFactor = -1.0f;
		else
			invertFactor = 1.0f;
		_XInput = X_val;
		_YInput = Y_val;


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
		// Rotate camera pivot (and NOT player) around X axis (along Y) with vertical mouse movements
		_cameraPivot.transform.RotateAround (_cameraPivot.transform.position, _cameraPivot.transform.right,
			- _YInput * CAMERA_Y_FACTOR * invertFactor);
		MoveCamera ();

		RpcUpdateCameraXY (X_val, Y_val);
	}

	[ClientRpc]
	void RpcUpdateCameraXY (float X_val, float Y_val) {
		float invertFactor;
		if (_invertYAxis)
			invertFactor = -1.0f;
		else
			invertFactor = 1.0f;
		_XInput = X_val;
		_YInput = Y_val;


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
		// Rotate camera pivot (and NOT player) around X axis (along Y) with vertical mouse movements
		_cameraPivot.transform.RotateAround (_cameraPivot.transform.position, _cameraPivot.transform.right,
			- _YInput * CAMERA_Y_FACTOR * invertFactor);
		MoveCamera ();
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
		//MovePlayer ();
		//Debug.Log (_forwardRunningSpeed);
	}

	[ClientRpc]
	void RpcUpdateForwardSpeed (int d) {
		if (!isLocalPlayer)
			return;
		_forwardRunningSpeed = d * DEFAULT_SPEED;
		MovePlayer ();
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
		//MovePlayer ();
		//Debug.Log (_strafeSpeed);
	}

	[ClientRpc]
	void RpcUpdateStrafeSpeed (int d) {
		if (!isLocalPlayer)
			return;
		_strafeSpeed = d * STRAFE_FACTOR * DEFAULT_SPEED;
		//MovePlayer ();
	}
}
