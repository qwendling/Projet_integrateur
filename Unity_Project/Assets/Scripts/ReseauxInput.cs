using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using GameMessages;
using System.Net.Sockets;
using System.Net;
using UnityEngine.UI;
using System;

public class ReseauxInput : MonoBehaviour {
	public Dropdown panel;
	private ArrayList listeLeap = new ArrayList();


	public void connectToLeap()
	{
		Dropdown listeClients = panel.GetComponentInChildren<Dropdown>();
		int index = listeClients.value;
		SystemMessage mes = listeLeap[index-1] as SystemMessage;
		sendSystemMessage(mes.deviceId, mes.clientConnection, localIp(), MessageTypes.LINK_ESTABLISHED);
		print ("Connection etablished");
	}

	// Use this for initialization
	void Start () {
		NetworkServer.Listen (7500);
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

	public bool containsDevice(ArrayList liste, string deviceId)
	{
		foreach(SystemMessage item in liste)
		{
			if(String.Compare(item.deviceId, deviceId, false) == 0)
				return true;
		}

		return false;
	}
		
	public void onSystemMessage(NetworkMessage net)
	{
		SystemMessage sysmsg = net.ReadMessage<SystemMessage> ();
		print ("SYSMSG RECEIVED [LEAP DEVICE ID: " + sysmsg.deviceId + ", CLIENT CONNECTION ID: " + sysmsg.clientConnection + ", CONTENT: " + sysmsg.content + "]");
		if (sysmsg.content == MessageTypes.ASK_FOR_CONNECTION)
		{

			if ( !containsDevice(listeLeap, sysmsg.deviceId) )
			{
				listeLeap.Add(sysmsg);
				Dropdown listeClients = panel.GetComponentInChildren<Dropdown>();
				listeClients.options.Add(new Dropdown.OptionData(sysmsg.deviceId));
			}

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



	
	// Update is called once per frame
	void Update () {
		
	}
}
