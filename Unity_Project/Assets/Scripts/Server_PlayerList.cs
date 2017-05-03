using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Server_PlayerList : NetworkBehaviour {

	[SyncVar]
	int _NbPlayers = 0;


	SyncListInt _Scores;
	SyncListString _Names;

	[SyncVar]
	bool _Mutex = false;


	// Use this for initialization
	void Start () {
		if (!isServer) {
			return;
		}
		_Scores = new SyncListInt();
		_Names = new SyncListString();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlayerJoinedTheGame(string playerName){
		_NbPlayers++;
		_Names.Add(playerName);
		_Scores.Add(0);
	}

	public void MamaJustKilledAMan(string mama){

		while (_Mutex) {}
		_Mutex = true;
		for (int i = 0; i < _NbPlayers; i++) {
			if (mama == _Names [i]) {
				_Scores[i] = +100;
				break;
			}
		}
		_Mutex = false;
	}
}
