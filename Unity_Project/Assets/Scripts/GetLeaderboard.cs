using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class GetLeaderboard : NetworkBehaviour {


	public GameObject _Coord;

	public string[] _Players;
	public int[] _Scores;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		string leaderBoard = "LEADERBOARD\n";

		_Players = _Coord.GetComponent<Server_PlayerList> ().GetNames ();
		_Scores = _Coord.GetComponent<Server_PlayerList> ().GetScores ();

		for (int i = 0; i < _Players.Length; i++) {
			leaderBoard = leaderBoard + this._Players[i] + " - " + this._Scores[i] + " points\n";
		}
		this.GetComponent<Text> ().text = leaderBoard;
	}
}
