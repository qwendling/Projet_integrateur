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

	public int commande{
		get {
			return gameObject.GetComponent<PlayerInput> ().commande;
		}
		set{
			gameObject.GetComponent<PlayerInput> ().commande = value;
		}
	}


	// Use this for initialization
	void Start () {
		NetworkServer.Listen (7500);
		NetworkServer.RegisterHandler (200, onGameMessage);
		print ("Server is listening on : " + NetworkServer.listenPort);
	}
		

	public void onGameMessage(NetworkMessage net)
	{
		DataMessage msg = net.ReadMessage<DataMessage> ();
		print ("DataMessage[ LEAP DEVICE ID: " + msg.deviceId + ", CODE MOUVEMENT: " + msg.mouvement + " ]");
		commande = msg.mouvement;
	}

	// Update is called once per frame
	void Update () {

	}
}
