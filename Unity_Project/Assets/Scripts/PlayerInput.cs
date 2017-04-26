using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using GameMessages;
using System.Net.Sockets;
using System.Net;

public class PlayerInput : NetworkBehaviour {
	public GameObject _player;

	private PlayerController _controller;
	private PlayerHealth _health;
	private ToolSwap _swapper;
	private CanShoot _shoot;

	private float timebetweenShot;
	private bool isFire = false;
	private double _timeShot;

	private int commande; // COMMANDE LEAP

	// Use this for initialization
	void Start () {
    
		_controller = _player.GetComponent<PlayerController> ();
		_health = _player.GetComponent<PlayerHealth> ();
		_swapper = _player.GetComponent<ToolSwap> ();
		_shoot = _player.GetComponent<CanShoot> ();
		//timebetweenShot = _swapper._activeItem.GetComponent<Weapon>().cadence; NE FONCTIONNE PAS 

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
		if (isServer) {
			// MDR
		}

		if (Input.GetKeyDown (KeyCode.T)) {
			Time.timeScale = 0;
		}

		if(!isLocalPlayer)
			return;

		// SHOOT COMMAND

		if (Input.GetButtonDown("Fire1") || (commande == 120))
		{
			isFire = true;
			timebetweenShot = _swapper._activeItem.GetComponent<Weapon>().cadence;
			_shoot.CmdFire ();
			_timeShot = timebetweenShot;
			print (_timeShot);
		}

		if (Input.GetButtonUp("Fire1"))
		{
			isFire = false;
		}
		if (isFire) {
			if (_timeShot <= 0) {
				_shoot.CmdFire ();
				_timeShot = timebetweenShot;
			} else {
				_timeShot -= 1.0 * Time.deltaTime;
			}
		}

		// CAMERA CONTROL

		_controller.CmdUpdateCameraXY (Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

		// MOVEMENT CONTROL

		int forward, right;

		if (Input.GetKey (KeyCode.Z) || (commande == 110 ) ) {
			forward = 1;
		} else if (Input.GetKey (KeyCode.S)) {
			forward = -1;
		} else {
			forward = 0;
		}

		_controller.CmdUpdateForwardSpeed (forward);

		if (Input.GetKey (KeyCode.D) || (commande == 610 )) {
			right = 1;
		} else if (Input.GetKey (KeyCode.Q) || (commande == 510 ) ) {
			right = -1;
		} else {
			right = 0;
		}

		_controller.CmdUpdateStrafeSpeed (right);

		// WEAPON SWAP

		// For some reason, sending message "swap" with 0 as argument won't work,
		// because 0 is interpreted as null (╯°□°）╯︵ ┻━┻
		// int i = 0;
		if(Input.GetKeyDown (KeyCode.Alpha1)){
			_swapper.CmdSwap (0);
			timebetweenShot = _swapper._activeItem.GetComponent<Weapon>().cadence;
		}
		if(Input.GetKeyDown (KeyCode.Alpha2) || (commande == 999 ) ){
			_swapper.CmdSwap (1);
			timebetweenShot = _swapper._activeItem.GetComponent<Weapon>().cadence;
		}
		if(Input.GetKeyDown (KeyCode.Alpha3)){
			_swapper.CmdSwap (2);
			timebetweenShot = _swapper._activeItem.GetComponent<Weapon>().cadence;
		}
	}
}
