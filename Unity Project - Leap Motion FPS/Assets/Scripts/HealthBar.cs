using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    public float TotalHt;
    public float CurrentHt;

	// Use this for initialization
	void Start () {
        CurrentHt = TotalHt;
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            GetDamage();
        }
	}

    void GetDamage()
    {
        CurrentHt -= 5;
        //transform.localScale = new Vector3((CurrentHt/TotalHt),1,1);
        Debug.Log((CurrentHt / TotalHt));
        Vector3 rowX = new Vector3(-28.5f, 0, 0);
        transform.Translate(rowX);
    }
}
