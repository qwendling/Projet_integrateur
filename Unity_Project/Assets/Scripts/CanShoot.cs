using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CanShoot : NetworkBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!isLocalPlayer)
            return;
        if (Input.GetButtonDown("Fire1"))
        {
			CmdFire ();
        }
	}

	[Command]
	public void CmdFire () {
		gameObject.GetComponent<ToolSwap> ()._activeItem.GetComponent<Weapon> ().Shoot ();
	}

}
