using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using Leap.Unity;
using Leap;
using GameMessages;

public class LeapMotionController : MonoBehaviour {
	LeapProvider provider;
	double marge= 0.4;
	double marge_pitch= 0.5;
	float yaw_max, yaw_min;
	float pitch_max, pitch_min;
	int change_arme= 0;

	const string srvaddr = "localhost";
	const int port = 7000;
	NetworkManager netmgr;

	public String getServerInfo()
	{
		return ("Server address: " + netmgr.networkAddress + " on port: " + netmgr.networkPort);
	}

	public void dataSend(short type, int mouvement)
	{
		GameMessage msg = new GameMessage ();
		msg.mouvement = mouvement;

		if(netmgr.client.isConnected) 
		{
			netmgr.client.Send (type, msg);
		}
	}

	void Start ()
	{
		//Set Network Manager
		netmgr = gameObject.GetComponent<NetworkManager>();

		//Configure Network Manager parameters
		netmgr.networkAddress = srvaddr;
		netmgr.networkPort = port;

		print("Client was configured to: " + getServerInfo());

		//Connect to the game server
		//Attempt to connect to the defined server
		netmgr.StartClient(); 

		provider = FindObjectOfType<LeapProvider>() as LeapProvider;
	}

	void Update ()
	{
		Frame frame = provider.CurrentFrame;
		foreach (Hand hand in frame.Hands)
		{
			float pitch = hand.Direction.Pitch;
			float yaw = hand.Direction.Yaw;
			float roll = hand.PalmNormal.Roll;

			print("yaw: " + yaw + " pitch: " + pitch);

			if (hand.IsLeft) {
				if (yaw < yaw_min)
					yaw_min = yaw;
				else if ( yaw > yaw_max)
					yaw_max = yaw;
				
				if (pitch < pitch_min)
					pitch_min = pitch;
				else if (pitch > pitch_max)
					pitch_max = pitch;

				if (yaw - marge > yaw_min && yaw < 0)
				{
					dataSend (200, 310);
					print ("left");
				}
				else if (yaw + marge < yaw_max && yaw > 0)
				{
					dataSend (200, 320);
					print ("right");
				}
				else
				{
					dataSend (200, 999);
					print("centre");
				}

				if (pitch - marge_pitch > pitch_min && pitch < 0)
				{
					dataSend (200, 998);
					print ("forward");
				}
				else if (pitch + marge_pitch < pitch_max && pitch > 0)
				{
					dataSend (200, 997);
					print ("backward");
				}
				else
				{
					dataSend (200, 996);
					print("stay");
				}
			}


			else if (hand.IsRight)
			{
				if(hand.PinchStrength > 0.6)
					print("Feu");
				if(pitch < 1.9 && pitch > 0)
					change_arme = 1;
				if(pitch  <= 0.2)
					if(change_arme == 1)
					{
						change_arme = 0;
						dataSend (200, 888);
						print("changement d'arme");
					}
			}
		}
	}

}
