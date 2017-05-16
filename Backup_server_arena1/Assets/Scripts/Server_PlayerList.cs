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
	}
}
