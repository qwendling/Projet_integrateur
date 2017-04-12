using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerHealthTest : NetworkBehaviour {

	public const int MAX_HEALTH = 100;

	[SyncVar(hook = "OnChangeHealth")]
	public int currentHealth = MAX_HEALTH;

	public RectTransform healthBar;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}


	public void TakeDamage(int amount) {
		if (!isServer)
			return;

		currentHealth -= amount;
		if (currentHealth <= 0) {
			currentHealth = MAX_HEALTH;
			RpcRespawn ();
		}
	}

	void OnChangeHealth (int health) {
		if (healthBar == null)
			return;
		healthBar.sizeDelta = new Vector2 (currentHealth, healthBar.sizeDelta.y);
	}

	[ClientRpc]
	void RpcRespawn() {
		if (isLocalPlayer) {
			//TODO
				// Score dead /2
				// Score killer++
			this.GetComponent<PlayerSpawn>().RandomSpawn();
		}
	}
}

