using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using GameMessages;
using System.Net.Sockets;
using System.Net;

public class ReseauxInput : NetworkBehaviour {

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
		NetworkServer.RegisterHandler (100, onSystemMessage);
		print ("Server is listening on : " + NetworkServer.listenPort);
	}

	// LEAP

	public void sendSystemMessage(string deviceId, int connectionId,string clientIpAddress, int content)
	{
		SystemMessage msg = new SystemMessage ();
		msg.deviceId = deviceId;
		msg.clientConnection = connectionId;
		msg.clientIpAddress = clientIpAddress;
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
			sendSystemMessage(sysmsg.deviceId, sysmsg.clientConnection, localIp(), MessageTypes.LINK_ESTABLISHED);
			print ("Connection etablished");
		}
	}

	public string localIp()
	{
		IPHostEntry host;
		string localIP = "";
		host = Dns.GetHostEntry (Dns.GetHostName ());
		foreach (IPAddress ip in host.AddressList) {
			if (ip.AddressFamily == AddressFamily.InterNetwork) {
				localIP = ip.ToString ();
				break;
			}
		}
		return localIP;
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
