using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerOverHeat : NetworkBehaviour {
	// La chaleur est representee en pourcentage
	public const int MAX_HEAT = 100;
	// Delais de refroidissement de l'arme (en sec)
	public const float HEAT_COOLDOWN = 3.0f;
	public const int HEAT_PER_SHOT = 10;

	[SyncVar(hook = "OnHeatChange")]
	public int currentHeat = 0;
	[SyncVar(hook = "OnOverHeat")]
	public bool overHeat = false;



	public RectTransform heatBar;
	private float _maxBar;

	// Timer pour le refroidissement
	private float _timer = 1.0f;

	// Use this for initialization
	void Start () {
		_maxBar = heatBar.sizeDelta.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isServer)
			return;

		_timer -= 4.0f * Time.deltaTime;
		if (_timer <= 0.0f) {
			_timer = 1.0f;
			if (currentHeat > 0) {
				currentHeat -= (int) (0.25f * (float)MAX_HEAT / (HEAT_COOLDOWN - 0.25f));
			}
		}
	}


	[Command]
	public void CmdHeat() {
		currentHeat += HEAT_PER_SHOT;
		if (currentHeat >= MAX_HEAT) {
			overHeat = true;
		}
	}

	/*[ClientRpc]
	void RpcHeat(){
		overHeat = true;
	}*/

	void OnHeatChange(int heat) {
		if (heatBar == null)
			return;
		Vector3 rowX = new Vector3(_maxBar-(((float)heat/(float)MAX_HEAT)*_maxBar),0,0);
		heatBar.transform.position -= rowX;
	}

	void OnOverHeat(bool isOverHeat) {
		gameObject.GetComponent<PlayerInput> ().OverHeat (isOverHeat);
	}
}
