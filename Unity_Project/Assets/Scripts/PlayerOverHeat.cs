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

	public RectTransform heatBar;

	// Timer pour le refroidissement
	private float _timer = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!isLocalPlayer)
			return;

		_timer -= 4.0f * Time.deltaTime;
		if (_timer <= 0.0f) {
			_timer = 1.0f;
			Debug.Log (currentHeat);
			if (currentHeat > 0) {
				currentHeat -= (int) (0.25f * (float)MAX_HEAT / (HEAT_COOLDOWN - 0.25f));
			}
		}
	}

	// Retourne true si l'arme entre en surchauffe, false sinon
	public bool Heat() {
		currentHeat += HEAT_PER_SHOT;
		if (currentHeat >= MAX_HEAT) {
			return true;
		}
		return false;
	}

	void OnHeatChange(int heat) {
		if (heatBar == null)
			return;
		heatBar.sizeDelta = new Vector2 (heat, heatBar.sizeDelta.y);
	}
}
