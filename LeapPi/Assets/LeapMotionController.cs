using System.Collections;
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

	double marge= 0.3;
	double marge_pitch= 0.6;
	float yaw_max, yaw_min;
	float pitch_max, pitch_min;
	int change_arme= 0;
	int i=0;
	int gauche=0 ,gauche1=0, gauche2=0;
	int prevtir=0;
	int start=0;
	int hand_counter= 0;
	int cam_horizon1= 0, cam_vertical1= 0, avancer1= 0, decaler1= 0, tirer1= 0, changerarme1=0;

	//System related attributes
	string identifier;
	bool deviceLinked = false;
	bool ack= false;
	string clientIp;

	//Network related attributes
	NetworkClient netcln = new NetworkClient();

	public void sendGameMessage(int cam_horizon, int cam_vertical, int avancer, int decaler, int tirer, int changerarme)
	{
		if (netcln.connection != null) 
		{
			GameMessage msg = new GameMessage ();
			msg.deviceId = this.identifier;
			msg.cam_horizon = cam_horizon;
			msg.cam_vertical = cam_vertical;
			msg.avancer = avancer;
			msg.decaler = decaler;
			msg.tirer = tirer;
			msg.changer_arme = changerarme;
			if(netcln.isConnected) 
			{
				netcln.Send(200, msg);
			}
		}
	}

	public void sendSystemMessage(int content)
	{
		if (netcln != null && netcln.connection != null) 
		{
			SystemMessage sysmsg = new SystemMessage ();
			sysmsg.deviceId = this.identifier;
			sysmsg.clientConnection = netcln.connection.connectionId;
			sysmsg.content = content;
			if (netcln.isConnected) 
			{
				netcln.Send(100, sysmsg);
			}
		}
	}

	public void onSystemMessage(NetworkMessage net)
	{
		SystemMessage sysmsg = net.ReadMessage<SystemMessage> ();
		if (sysmsg.content == MessageTypes.LINK_ESTABLISHED && !this.deviceLinked) 
		{
			this.deviceLinked = true;
			this.clientIp = sysmsg.clientIpAddress;

			netcln.Connect (this.clientIp, 7500);
			print ("Your MCD was successfully atached to the client: " + sysmsg.deviceId + " located on: " + sysmsg.clientIpAddress + " .");
		}
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
		netcln.Connect("255.255.255.255", 7500);

		//2.2 Register message handler(s)
		netcln.RegisterHandler(100, onSystemMessage);
	

		//3. Motion capture device link
		provider = FindObjectOfType<LeapProvider>() as LeapProvider;
	}

	void Update ()
	{		
		// compteur pour reduire le nombre d'images traités
		i = i + 1;
		if (!deviceLinked) 
		{
			if (i == 10) {
				i = 0;
				//Connection phase
				sendSystemMessage(MessageTypes.ASK_FOR_CONNECTION);
			}
		} 
		else
		{
			if (!ack && netcln.isConnected) {
				sendSystemMessage (MessageTypes.ACK_LINK_ESTABLISHED);
				ack = true;
			} else if(netcln.isConnected) {
				Frame frame = provider.CurrentFrame;
				hand_counter = 0;
				foreach (Hand hand in frame.Hands) {
					hand_counter++;
					float pitch = hand.Direction.Pitch;
					float yaw = hand.Direction.Yaw;
					float roll = hand.PalmNormal.Roll;
					print ("roll : " + roll);

					if (hand.IsLeft) {
						//enregistrement des min et max
						if (yaw < yaw_min)
							yaw_min = yaw;
						else if (yaw > yaw_max)
							yaw_max = yaw;

						if (pitch < pitch_min)
							pitch_min = pitch;
						else if (pitch > pitch_max)
							pitch_max = pitch;


						if (yaw - marge > yaw_min && yaw < 0) {
							gauche = 10;
							//print ("left");
						} else if (yaw + marge < yaw_max && yaw > 0) {
							//print ("right");
							gauche = 20;
						} else
							gauche = 0;

						if (roll - marge > 0 && roll > 0) {
							decaler1 = 20;
						} else if (roll + marge < 0 && roll < 0) {
							decaler1 = 10;
						} else {
							decaler1 = 0;
						}

						if (pitch - marge_pitch + 0.1 > -3 && pitch < 0) {
							gauche1 = 20;
							//print ("down");
						} else if (pitch + marge_pitch < 3 && pitch > 0) {
							gauche1 = 10;
							//print ("up");
						} else
							gauche1 = 0;

						//avancer
						if (hand.PinchStrength > 0.6) {
							gauche2 = 10;
						} else
							gauche2 = 0;

						if (gauche == 0 && (cam_horizon1 == 10 || cam_horizon1 == 20)) {
							cam_horizon1 = cam_horizon1 + 1;
						} else if (gauche != 0) {
							cam_horizon1 = gauche;
						} else
							cam_horizon1 = 0;

						if (gauche1 == 0 && (cam_vertical1 == 10 || cam_vertical1 == 20)) {
							cam_vertical1 = cam_vertical1 + 1;
						} else if (gauche1 != 0) {
							cam_vertical1 = gauche1;
						} else
							cam_vertical1 = 0;

						if (gauche2 == 0 && avancer1 == 10) {
							//print ("stoper");
							avancer1 = 11;
						} else if (gauche2 == 10) {
							avancer1 = 10;
						} else
							avancer1 = 0;

					} 

					// main droite
					else if (hand.IsRight) {
						//si on ferme le poing on tire
						if (hand.PinchStrength > 0.6 && tirer1 != 10) {
							tirer1 = 10;
							prevtir = 1;
						} else if (hand.PinchStrength < 0.6 && tirer1 == 10) {
							prevtir = 0;
							tirer1 = 11;
						} else
							tirer1 = 0;


						//print (pitch);
						// si on leve la main on enregistre
						if (pitch < 1.9 && pitch > 0)
							change_arme = 1;
						//si on a lever la main et on la baisse on change d'arme
						if ((pitch > 2.5 && pitch > 0) || pitch < 0) {
							if (change_arme == 1) {
								change_arme = 0;
								changerarme1 = 10;
							} else
								changerarme1 = 0;
						}
							
					}

					sendGameMessage (cam_horizon1, cam_vertical1, avancer1, decaler1, tirer1, changerarme1);
				}
				if (hand_counter == 0)
					sendGameMessage (0, 0, 0, 0, 0, 0);
			}
		}
	}
}
