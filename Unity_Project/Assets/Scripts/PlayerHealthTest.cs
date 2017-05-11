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
	public GameObject _Coord;

	public bool protectionIsOn = false; //bouclier désactivé par défaut


	// Use this for initialization
	void Start () {
		_Coord = GameObject.Find ("Coordinator");
	}

	// Update is called once per frame
	void Update () {

	}


	public void TakeDamage(int amount, string opponentName) {
		if (!isServer)
			return;

		// si bouclier actif, dégat réduit de moitié
		if(protectionIsOn = true)
			amount = amount/2;

		currentHealth -= amount;
		if (currentHealth <= 0) {
			if (opponentName != null) {
				_Coord.GetComponent<Server_PlayerList> ().MamaJustKilledAMan (opponentName);
			}
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
		healthBar.sizeDelta = new Vector2 (health, healthBar.sizeDelta.y);
	}

	[ClientRpc]
	void RpcRespawn() {
		if (isLocalPlayer) {
			this.GetComponent<PlayerSpawn>().RandomSpawn();
		}
	}
}
