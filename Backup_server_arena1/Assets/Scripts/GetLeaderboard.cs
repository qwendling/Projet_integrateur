<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetLeaderboard : MonoBehaviour {


	public GameObject _Coord;

	public List<string> _Players = new List<string> ();
	public List<int> _Scores = new List<int> ();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateLeaderBoard(){

		int idx_max = 0;
		_Players = new List<string> ();
		_Scores = new List<int> ();
		for (int i = 0; i < _Coord.GetComponent<Server_PlayerList> ()._NbPlayers; i++) {
			
			this._Players.Add (_Coord.GetComponent<Server_PlayerList> ()._Names [i]);
			this._Scores.Add (_Coord.GetComponent<Server_PlayerList> ()._Scores [i]);
		}

		int[] temp = new int[_Coord.GetComponent<Server_PlayerList> ()._NbPlayers];
		this._Scores.CopyTo (temp);
		int[] Ranking = new int[temp.Length];

		for (int i = 0; i < temp.Length; i++) {
			idx_max = 0;
			for (int j = 0; j < temp.Length; j++) {
				if (temp [j] > temp [idx_max]) {
					idx_max = j;
				}
			}
			Ranking [i] = idx_max;
			temp [idx_max] = -1;
		}

		string leaderBoard = "LEADERBOARD\n";
		for (int i = 0; i < Ranking.Length; i++) {
			leaderBoard = leaderBoard + this._Players [Ranking [i]] + " - " + this._Scores [Ranking [i]] + " points\n";
		}
		this.GetComponent<Text> ().text = leaderBoard;
	}
}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetLeaderboard : MonoBehaviour {


	public GameObject _Coord;

	public List<string> _Players = new List<string> ();
	public List<int> _Scores = new List<int> ();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateLeaderBoard(){

		int idx_max = 0;
		_Players = new List<string> ();
		_Scores = new List<int> ();
		for (int i = 0; i < _Coord.GetComponent<Server_PlayerList> ()._NbPlayers; i++) {
			
			this._Players.Add (_Coord.GetComponent<Server_PlayerList> ()._Names [i]);
			this._Scores.Add (_Coord.GetComponent<Server_PlayerList> ()._Scores [i]);
		}

		int[] temp = new int[_Coord.GetComponent<Server_PlayerList> ()._NbPlayers];
		this._Scores.CopyTo (temp);
		int[] Ranking = new int[temp.Length];

		for (int i = 0; i < temp.Length; i++) {
			idx_max = 0;
			for (int j = 0; j < temp.Length; j++) {
				if (temp [j] > temp [idx_max]) {
					idx_max = j;
				}
			}
			Ranking [i] = idx_max;
			temp [idx_max] = -1;
		}

		string leaderBoard = "LEADERBOARD\n";
		for (int i = 0; i < Ranking.Length; i++) {
			leaderBoard = leaderBoard + this._Players [Ranking [i]] + " - " + this._Scores [Ranking [i]] + " points\n";
		}
		this.GetComponent<Text> ().text = leaderBoard;
	}
}
>>>>>>> origin/master
