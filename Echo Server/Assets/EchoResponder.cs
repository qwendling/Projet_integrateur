using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine;
using GameMessages;

public class EchoResponder : MonoBehaviour 
{	
	public void sendSystemMessage(string deviceId, int connectionId, int content)
	{
		SystemMessage msg = new SystemMessage ();
		msg.deviceId = deviceId;
		msg.clientConnection = connectionId;
		msg.content = content;

		NetworkServer.SendToClient (connectionId, 100, msg);
	}

	public void onSystemMessage(NetworkMessage net)
	{
		SystemMessage sysmsg = net.ReadMessage<SystemMessage> ();
		print ("SYSMSG RECEIVED [LEAP DEVICE ID: " + sysmsg.deviceId + ", CLIENT CONNECTION ID: " + sysmsg.clientConnection + ", CONTENT: " + sysmsg.content + "]");
		if (sysmsg.content == MessageTypes.ASK_FOR_CONNECTION) 
		{
			//Create database entry with device link
			//Confirm
			sendSystemMessage(sysmsg.deviceId, sysmsg.clientConnection, MessageTypes.LINK_ESTABLISHED);
		}
	}
	

	public void onGameMessage(NetworkMessage net)
	{
		DataMessage msg = net.ReadMessage<DataMessage> ();
		print ("DataMessage[ LEAP DEVICE ID: " + msg.deviceId + ", CODE MOUVEMENT: " + msg.mouvement + " ]");
	}

	// Use this for initialization
	void Start () 
	{
		NetworkServer.Listen (7500);
		NetworkServer.RegisterHandler (200, onGameMessage);
		NetworkServer.RegisterHandler (100, onSystemMessage);

		print ("Server is listening on : " + NetworkServer.listenPort);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
