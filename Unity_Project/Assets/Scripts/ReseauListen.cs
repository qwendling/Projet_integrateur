using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using GameMessages;
using System.Net.Sockets;
using System.Net;
using UnityEngine.UI;
using System;

public class ReseauListen : MonoBehaviour {

	public GameObject Player;
	DataMessage msg;

	public int commande{
		get {
			return Player.GetComponent<PlayerInput> ().commande;
		}
		set{
			Player.GetComponent<PlayerInput> ().commande = value;
		}
	}


	// Use this for initialization
	void Start () {
		NetworkServer.RegisterHandler (200, onGameMessage);
		print ("Server is listening on : " + NetworkServer.listenPort);
	}


	public void onGameMessage(NetworkMessage net)
	{
		msg = net.ReadMessage<DataMessage> ();
		print ("DataMessage[ LEAP DEVICE ID: " + msg.deviceId + ", CODE MOUVEMENT: " + msg.mouvement + " ]");

		//commande = msg.mouvement;

	}

	// Update is called once per frame
	void Update () {
		

	}
}
