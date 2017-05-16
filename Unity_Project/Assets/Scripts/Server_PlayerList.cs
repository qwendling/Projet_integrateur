using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Server_PlayerList : NetworkBehaviour {

	[SyncVar]
	public int _NbPlayers = 0;


	public SyncListInt _Scores = new SyncListInt ();
	public SyncListString _Names = new SyncListString ();

	[SyncVar]
	bool _Mutex = false;


	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlayerJoinedTheGame(string playerName){
		_NbPlayers++;
		_Names.Add(playerName);
		_Scores.Add(0);
		UpdateRanks ();
	}

	public void MamaJustKilledAMan(string mama){

		//while (_Mutex) {}
		_Mutex = true;
		for (int i = 0; i < _NbPlayers; i++) {
			if (mama == _Names [i]) {
				_Scores[i] = +100;
				break;
			}
		}
		for (int i = 0; i < _Names.Count; i++) {
			Debug.Log (_Names [i] + " - " + _Scores [i] + " points");
		}
		_Mutex = false;
		UpdateRanks ();

	}

	public void UpdateRanks(){
		int idx_max = 0;
		string[] _PlayersTemp = new string[_NbPlayers];
		string[] _ScoresTempBeforeSplitting = new string[_NbPlayers];
		int[] _ScoresTemp = new int[_NbPlayers];

		for (int i = 0; i < _NbPlayers; i++) {
			_ScoresTemp [i] = _Scores[i];
			_PlayersTemp[i] = _Names[i];
			Debug.Log (_PlayersTemp[i] + " --- " + _ScoresTemp [i]);
		}

		int[] temp = new int[_NbPlayers];
		_ScoresTemp.CopyTo (temp, 0);
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

		_Scores = new SyncListInt ();
		_Names = new SyncListString ();
		for (int i = 0; i < _NbPlayers; i++) {
			_Scores.Add (temp [i]);
			_Names.Add (_PlayersTemp [i]);
		}
	}

	public string[] GetNames(){
		string[] _PlayersTemp = new string[_NbPlayers];
		for (int i = 0; i < _NbPlayers; i++) {
			_PlayersTemp[i] = _Names[i];
		}
		return _PlayersTemp;
	}

	public string[] GetScores(){
		string[] _ScoresTemp = new string[_NbPlayers];
		for (int i = 0; i < _NbPlayers; i++) {
			_ScoresTemp[i] = _Scores[i].ToString();
		}
		return _ScoresTemp;
	}
}
