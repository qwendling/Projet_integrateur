<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CameraManager : NetworkBehaviour {
	public Camera _myCamera;
	public GameObject _HUD;
	
	// Use this for initialization
	void Start () {
		if(!isLocalPlayer){
			_myCamera.enabled = false;
			_myCamera.GetComponent<AudioListener> ().enabled = false;
			_HUD.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CameraManager : NetworkBehaviour {
	public Camera _myCamera;
	public GameObject _HUD;
	
	// Use this for initialization
	void Start () {
		if(!isLocalPlayer){
			_myCamera.enabled = false;
			_myCamera.GetComponent<AudioListener> ().enabled = false;
			_HUD.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
>>>>>>> origin/master
