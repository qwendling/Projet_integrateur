<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

// Generic PowerUp class
public class PowerUp : NetworkBehaviour {
	// Reference to PowerUp Manager
	public GameObject PU_Man;
	private PU_Manager _manager;

	// PowerUp spawn delay (in sec)
	private float _delay;
	private float _timer;

	// Limits
	private float MIN_DELAY = 15;
	private float MAX_DELAY = 30;

	// Give PowerUp only if spawned
	private bool _isSpawned = false;

	// Current spawned PU type
	private PU_Manager.PU _currentPU;
	// Current spawned PU Object
	private GameObject _puObject;

	// Bonus stats
	private int _healAmount = 50; 
	private float _acceleration = 2.0f;

	// Use this for initialization
	void Start () {
		if (!isServer)
			return;
		
		_manager = PU_Man.GetComponent<PU_Manager> ();

		_delay = MIN_DELAY;
		StartTimer ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!isServer)
			return;
		
		if (TimerFinished () && !_isSpawned) {
			// spawn power up
			_currentPU = _manager.ChoosePU();
			_puObject = Instantiate (_manager.PU_List [(int)_currentPU - 1], transform.position, transform.rotation);
			NetworkServer.Spawn (_puObject);
			_isSpawned = true;
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

	// If a player steps in the powerup zone
	void OnTriggerEnter (Collider c) {
		if (!isServer)
			return;
		
		if (c.tag == "Player" && _isSpawned) {
			// Unspawn
			Destroy(_puObject);

			// Give bonus
			switch (_currentPU) {
			case PU_Manager.PU.MSBoost:
				c.gameObject.GetComponent<PlayerBonus> ().Heal (_healAmount);
				Debug.Log ("Healing");
				break;

			case PU_Manager.PU.Heal:
				c.gameObject.GetComponent<PlayerBonus> ().SpeedUp (_acceleration);
				Debug.Log ("MSBoost");
				break;

			default:
				break;
			}

			_isSpawned = false;
			_delay = Random.Range (MIN_DELAY, MAX_DELAY);
			StartTimer ();
		}
	}
}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

// Generic PowerUp class
public class PowerUp : NetworkBehaviour {
	// Reference to PowerUp Manager
	public GameObject PU_Man;
	private PU_Manager _manager;

	// PowerUp spawn delay (in sec)
	private float _delay;
	private float _timer;

	// Limits
	private float MIN_DELAY = 15;
	private float MAX_DELAY = 30;

	// Give PowerUp only if spawned
	private bool _isSpawned = false;

	// Current spawned PU type
	private PU_Manager.PU _currentPU;
	// Current spawned PU Object
	private GameObject _puObject;

	// Bonus stats
	private int _healAmount = 50; 
	private float _acceleration = 2.0f;

	// Use this for initialization
	void Start () {
		if (!isServer)
			return;
		
		_manager = PU_Man.GetComponent<PU_Manager> ();

		_delay = MIN_DELAY;
		StartTimer ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!isServer)
			return;
		
		if (TimerFinished () && !_isSpawned) {
			// spawn power up
			_currentPU = _manager.ChoosePU();
			_puObject = Instantiate (_manager.PU_List [(int)_currentPU - 1], transform.position, transform.rotation);
			NetworkServer.Spawn (_puObject);
			_isSpawned = true;
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

	// If a player steps in the powerup zone
	void OnTriggerEnter (Collider c) {
		if (!isServer)
			return;
		
		if (c.tag == "Player" && _isSpawned) {
			// Unspawn
			Destroy(_puObject);

			// Give bonus
			switch (_currentPU) {
			case PU_Manager.PU.MSBoost:
				c.gameObject.GetComponent<PlayerBonus> ().Heal (_healAmount);
				Debug.Log ("Healing");
				break;

			case PU_Manager.PU.Heal:
				c.gameObject.GetComponent<PlayerBonus> ().SpeedUp (_acceleration);
				Debug.Log ("MSBoost");
				break;

			default:
				break;
			}

			_isSpawned = false;
			_delay = Random.Range (MIN_DELAY, MAX_DELAY);
			StartTimer ();
		}
	}
}
>>>>>>> origin/master
