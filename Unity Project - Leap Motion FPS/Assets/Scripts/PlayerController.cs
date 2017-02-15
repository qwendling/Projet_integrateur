using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	// MACROS
	private const float CAMERA_TURN_FACTOR = 6.0f;		// camera sensibility
	private const float DEFAULT_SPEED = 3.0f;				// running speed 
	
	// Public variables
	public GameObject _cameraPivot;
	
	// Private variables
	private float _runningSpeed = 0;		// Current running speed
	private float _camRotX = 0.0f;			// Current camera rotation around X
	

	// Use this for initialization
	void Start () {
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		MoveCamera ();
	}
	
	// Move the camera along the axis 
	private void MoveCamera () {
		// Get axis input (will be Leap Motion input)
		float horizontalInput = Input.GetAxis("Mouse X");
		float verticalInput = Input.GetAxis("Mouse Y");
		_camRotX += verticalInput * CAMERA_TURN_FACTOR;

		// Rotate player around Y axis with horizontal mouse movements
		transform.RotateAround(transform.position, transform.up, 
			CAMERA_TURN_FACTOR * horizontalInput);

		// If the rotation exceeds 90° (up or down), ignore the rest.
		if (_camRotX < -90f) {
			_camRotX = -90f;
			return;
		}
		if (_camRotX > 90f) {
			_camRotX = 90f;
			return;
		}
		
		// Rotate camera pivot (and NOT player) around X axis with vertical mouse movements (not inverted)
		_cameraPivot.transform.RotateAround (_cameraPivot.transform.position, _cameraPivot.transform.right,
			- verticalInput * CAMERA_TURN_FACTOR);
	}
}
