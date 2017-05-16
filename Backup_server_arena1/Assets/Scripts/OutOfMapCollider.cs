<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class OutOfMapCollider : NetworkBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider hit) {
		if (hit.tag == "Player")
			hit.gameObject.GetComponent<PlayerHealthTest> ().TakeDamage (666, null);
	}
}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class OutOfMapCollider : NetworkBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider hit) {
		if (hit.tag == "Player")
			hit.gameObject.GetComponent<PlayerHealthTest> ().TakeDamage (666, null);
	}
}
>>>>>>> origin/master
