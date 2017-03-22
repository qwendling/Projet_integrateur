using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CameraManager : NetworkBehaviour {
	public Camera _myCamera;
	
	// Use this for initialization
	void Start () {
		/*if(!isLocalPlayer){
			_myCamera.enabled = false;
		}*/
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
