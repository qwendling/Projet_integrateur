using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
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
	}
}
