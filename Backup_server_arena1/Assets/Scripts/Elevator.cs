using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {

	private const float SLEEP_TIME = 3.0f;
	private bool _isGoingDown = false;
	public float _isSleeping = SLEEP_TIME;


	// Use this for initialization
	void Start () {

		transform.position = new Vector3 (-4.986f, 1.922f, -9.293f);
	}
	
	// Update is called once per frame
	void Update () {

		if (_isSleeping > 0.0f) {
			_isSleeping -= 1.0f * Time.deltaTime;
		} else {
			
			if (_isGoingDown) {

				if (transform.position.y > 1.922f) {
					transform.position = new Vector3 (transform.position.x,
						transform.position.y - 1.0f * Time.deltaTime,
						transform.position.z);
				} else {
					_isGoingDown = false;
					_isSleeping = SLEEP_TIME;

				}
			} else {
				
				if (transform.position.y < 6.485f) {
					transform.position = new Vector3 (transform.position.x,
						transform.position.y + 1.0f * Time.deltaTime,
						transform.position.z);
				} else {
					_isGoingDown = true;
					_isSleeping = SLEEP_TIME;

				}
			}
		}
	}
}
