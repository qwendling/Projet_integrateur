using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

// Generic PowerUp class
public class PowerUp : NetworkBehaviour {
	// Reference to PowerUp Manager
	public GameObject PU_Man;
	private PU_Manager _manager;

	// PowerUp spawn position
	private Vector3 _position;
	// PowerUp spawn delay (in sec)
	private float _delay;
	private float _timer;

	// Limits
	private float MIN_DELAY = 15;
	private float MAX_DELAY = 30;

	// Respawn only if PowerUp is consumed
	private bool _isConsumed = false;

	// Give PowerUp only if spawned
	private bool _isSpawned = false;

	// Current spawned PU type
	private PU_Manager.PU _currentPU;


	// Use this for initialization
	void Start () {
		_manager = PU_Man.GetComponent<PU_Manager> ();
		_position = new Vector3 (
			transform.position.x,
			transform.position.y,
			transform.position.z);

		_delay = MIN_DELAY;
		StartTimer ();
	}
	
	// Update is called once per frame
	void Update () {
		if (TimerFinished ()) {
			// TODO : spawn power up
			_currentPU = _manager.ChoosePU();
			_isSpawned = true;

			// When the power up is consumed, refresh timer
			if (_isConsumed) {
				_delay = Random.Range (MIN_DELAY, MAX_DELAY);
				_isConsumed = false;
				StartTimer ();
			}
		}
	}

	// Run the timer, return true if timer has ended
	bool TimerFinished () {
		_timer -= 1.0f * Time.deltaTime;
		return (_timer <= 0);
	}

	// Start/Refresh the timer
	void StartTimer () {
		_timer = _delay;
	}

	// If a player steps in the powerup
	void OnTriggerEnter (Collider c) {
		if (c.tag == "Player" && _isSpawned) {
			// TODO : Unspawn
			_isSpawned = false;
			_isConsumed = true;

			// TODO : Give bonus
			switch (_currentPU) {

			}
		}
	}
}
