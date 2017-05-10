using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerHealth : NetworkBehaviour {

	public const int MAX_HEALTH = 100;

	[SyncVar(hook = "OnChangeHealth")]
	public int currentHealth = MAX_HEALTH;

	public RectTransform healthBar;
	private float _barMax;

	// Use this for initialization
	void Start () {
		_barMax = healthBar.sizeDelta.x;
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

	public void HealUp(int amount) {
		if (!isServer)
			return;

		currentHealth += amount;
		if (currentHealth > MAX_HEALTH) {
			currentHealth = MAX_HEALTH;
		}
	}

	void OnChangeHealth (int health) {
		if (healthBar == null)
			return;
		Vector3 rowX = new Vector3(_barMax-(((float)health/(float)MAX_HEALTH)*_barMax),0,0);
		healthBar.transform.position -= rowX;
	}

	[ClientRpc]
	void RpcRespawn() {
		if (isLocalPlayer) {
			transform.position = Vector3.zero;
		}
	}
}
