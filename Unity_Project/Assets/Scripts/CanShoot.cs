using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanShoot : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
           gameObject.GetComponentInChildren<ToolSwap>()._activeItem.GetComponent<Weapon>().shoot();
        }
	}
}
