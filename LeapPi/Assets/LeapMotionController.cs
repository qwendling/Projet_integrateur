﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using Leap.Unity;
using Leap;
using GameMessages;

public class LeapMotionController : MonoBehaviour 
{
	//Motion capture device related attributes
	LeapProvider provider;

	double marge= 0.4;
	double marge_pitch= 0.2;
	float yaw_max, yaw_min;
	float pitch_max, pitch_min;
	int change_arme= 0;

	//System related attributes
	string identifier;
	bool deviceLinked = false;

	//Network related attributes
	NetworkManager netmgr;

	public void sendGameMessage(int mouvement)
	{
		if (netmgr.client.connection != null) 
		{
			GameMessage msg = new GameMessage ();
			msg.deviceId = this.identifier;
			msg.mouvement = mouvement;

			if(netmgr.client.isConnected) 
			{
				netmgr.client.Send (200, msg);
			}
		}
	}

	public void sendSystemMessage(int content)
	{
		if (netmgr.client != null && netmgr.client.connection != null) 
		{
			SystemMessage sysmsg = new SystemMessage ();
			sysmsg.deviceId = this.identifier;
			sysmsg.clientConnection = netmgr.client.connection.connectionId;
			sysmsg.content = content;

			if (netmgr.client.isConnected) 
			{
				netmgr.client.Send (100, sysmsg);
			}
		}
	}

	public void onSystemMessage(NetworkMessage net)
	{
		SystemMessage sysmsg = net.ReadMessage<SystemMessage> ();
		if (sysmsg.content == MessageTypes.LINK_ESTABLISHED && !this.deviceLinked) 
		{
			this.deviceLinked = true;
			print ("Link to device " + sysmsg.deviceId + " has been successfully established.");
		}
		//print ("SYSMSG RECEIVED [LEAP DEVICE ID: " + sysmsg.deviceId + ", CLIENT CONNECTION ID: " + sysmsg.clientConnection + ", CONTENT: " + sysmsg.content + "]");
	}

	void Start ()
	{
		//INITIAL CONFIGURATION
		//1. Device identity
		if (SystemInfo.deviceUniqueIdentifier != SystemInfo.unsupportedIdentifier) 
		{
			this.identifier = SystemInfo.deviceUniqueIdentifier;
		} 
		else 
		{
			this.identifier = SystemInfo.unsupportedIdentifier;
		}
			
		//2. Network setup
		//2.1 Retrieve NetworkManager object
		netmgr = gameObject.GetComponent<NetworkManager>();

		//2.2 Set game server parameters
		netmgr.networkAddress = "127.0.0.1";
		netmgr.networkPort = 3000;

		//2.3 Start client
		netmgr.StartClient(); 

		if (netmgr.client.isConnected)
			print ("Client connetcted!");

		//2.4 Register message handler(s)
		netmgr.client.RegisterHandler (100, onSystemMessage);

		//3. Motion capture device link
		provider = FindObjectOfType<LeapProvider>() as LeapProvider;
	}

	void Update ()
	{
		if (this.deviceLinked) 
		{
			Frame frame = provider.CurrentFrame;
			foreach (Hand hand in frame.Hands) 
			{
				float pitch = hand.Direction.Pitch;
				float yaw = hand.Direction.Yaw;
				float roll = hand.PalmNormal.Roll;

				if (hand.IsLeft) 
				{
					if (yaw < yaw_min)
						yaw_min = yaw;
					else if (yaw > yaw_max)
						yaw_max = yaw;

					if (pitch < pitch_min)
						pitch_min = pitch;
					else if (pitch > pitch_max)
						pitch_max = pitch;

					if (yaw - marge > yaw_min && yaw < 0) 
					{
						sendGameMessage (310);
						print ("left");
					} 
					else if (yaw + marge < yaw_max && yaw > 0) 
					{
						sendGameMessage (320);
						print ("right");
					}
					else 
					{
						sendGameMessage (330);
						print ("centre");
					}

					if (pitch - marge_pitch > pitch_min && pitch < 0) 
					{
						sendGameMessage (998);
						print ("forward");
					} 
					else if (pitch + marge_pitch < pitch_max && pitch < 0) 
					{
						sendGameMessage (997);
						print ("backward");
					} 
					else 
					{
						sendGameMessage (998);
						print ("stay");
					}
				} 
				else if (hand.IsRight) 
				{
					if (hand.PinchStrength > 0.6)
						print ("Feu");
					if (pitch < 1.9 && pitch > 0)
						change_arme = 1;
					if (pitch <= 0.2)
					if (change_arme == 1) 
					{
						change_arme = 0;
						sendGameMessage (999);
						print ("changement d'arme");
					}
				}
			}
		} 
		else 
		{
			sendSystemMessage (MessageTypes.ASK_FOR_CONNECTION);
		}
	}

}
