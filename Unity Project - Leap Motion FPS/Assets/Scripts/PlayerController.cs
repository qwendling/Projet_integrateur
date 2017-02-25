using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	// MACROS
	private const float CAMERA_X_FACTOR = 6.0f;		// camera sensibility (along X axis)
	private const float CAMERA_Y_FACTOR = 4.0f;		// camera sensibility (along Y axis)
	private const float DEFAULT_SPEED = 3.0f;		// running speed 
	
	// Public variables
	public GameObject _cameraPivot;
	public bool _invertYAxis;
	
	// Private variables
	private float _runningSpeed = 0;		// Current running speed
	private float _camRotX = 0.0f;			// Current camera rotation around X

	// Private values stocking vertical and horizontal input for camera
	private float _XInput;
	private float _YInput;

	// Public corresponding properties (to be updated)
	public float CamX {
		get { return _XInput; }
		set { _XInput = value; }
	}

	public float CamY {
		get { return _YInput; }
		set { _YInput = value; }
	}

	// Use this for initialization
	void Start () {
		// Hide cursor
		Cursor.visible = false;

		// Default Y camera axis is not inverted
		_invertYAxis = false;
	}
	
	// Update is called once per frame
	void Update () {
		MoveCamera ();
	}
	
	// Move the camera along the axis 
	private void MoveCamera () {
		float invertFactor;

		// Update current camera rotation around X to cap it
		_camRotX += CamY * CAMERA_Y_FACTOR;

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
			CAMERA_X_FACTOR * CamX);

		if (_invertYAxis)
			invertFactor = -1.0f;
		else
			invertFactor = 1.0f;

		// Rotate camera pivot (and NOT player) around X axis (along Y) with vertical mouse movements
		_cameraPivot.transform.RotateAround (_cameraPivot.transform.position, _cameraPivot.transform.right,
			- CamY * CAMERA_Y_FACTOR * invertFactor);
	}
}
