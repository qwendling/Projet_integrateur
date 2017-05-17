using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using GameMessages;
using System.Net.Sockets;
using System.Net;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerInput : NetworkBehaviour {
	public GameObject _player;
 

	private PlayerController _controller;
	private PlayerHealth _health;
	private ToolSwap _swapper;
	private CanShoot _shoot;
	private PlayerOverHeat _POH;
	public Animator anim;

	private bool _isOverheat = false;

	private float timebetweenShot;
	private double _timeShot;
  
  private Dropdown panel;
  private Button validButton;
  
	private ArrayList listeLeap = new ArrayList();



  // Mouvements leap motion
	public int cam_horizon;
	public int cam_vertical;
	public int avancer;
	public int decaler;
	public int tirer;
	public int changer_arme;

  public int armes=-1;
  public int frame=0;
  public int changer=1;

	private float _heatTimer;
  
  	public void connectToLeap()
	{
		Dropdown listeClients = panel.GetComponentInChildren<Dropdown>();
		int index = listeClients.value;
		SystemMessage mes = listeLeap[index-1] as SystemMessage;
		sendSystemMessage(mes.deviceId, mes.clientConnection, localIp(), MessageTypes.LINK_ESTABLISHED);
		print ("Connection established");
    
    //panel.gameObject.SetActive(false);
    GameObject.Find("MenuLeap").SetActive(false);
	}


	// Use this for initialization
	void Start () {
		_controller = _player.GetComponent<PlayerController> ();
		_health = _player.GetComponent<PlayerHealth> ();
		_swapper = _player.GetComponent<ToolSwap> ();
		_shoot = _player.GetComponent<CanShoot> ();
		_POH = gameObject.GetComponent<PlayerOverHeat> ();
		GameObject.Find("MenuLeap").SetActive(false);

    while(panel ==null){
      panel = GameObject.Find("Dropdown").GetComponent<Dropdown>();
    }
    /*
    if(isLocalPlayer){
     
      while(validButton == null){
        validButton=GameObject.Find("VALIDATION_BUTTON").GetComponent<Button>();
      }
      validButton.onClick.AddListener(() => {connectToLeap();});
    }
    

    NetworkServer.Listen (7500);
		NetworkServer.RegisterHandler (100, onSystemMessage);
    NetworkServer.RegisterHandler (200, onGameMessage);
		print ("Server is listening on : " + NetworkServer.listenPort);*/

		_timeShot = -1.0;
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
    else if (sysmsg.content == MessageTypes.ACK_LINK_ESTABLISHED)
    {
      print("Changement de scene");

     //SceneManager.LoadScene ("ConnectionMenu");
     // Cursor.visible = false;
			//NetworkServer.Shutdown();
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
		print ("DataMessage[ LEAP DEVICE ID: " + msg.deviceId + "avancer: "+msg.avancer + "cam_horizon : " + msg.cam_horizon + "cam_vertical: "+msg.cam_vertical + "tirer: "+msg.tirer + "changer_arme: "+msg.changer_arme + "decaler: "+msg.decaler);

	 cam_horizon=msg.cam_horizon;
	 cam_vertical=msg.cam_vertical;
	 avancer=msg.avancer;
	 decaler=msg.decaler;
	 tirer=msg.tirer;
	 changer_arme=msg.changer_arme;

	}
  
  

	// Update is called once per frame
	void Update () {
		if (isServer) {
			RpcOnOverheat ();
		}


		if(!isLocalPlayer)
			return;

		if (HeatTimerFinished ()) {
			_isOverheat = false;
		}

		if (_swapper._activeItem == null) {
			return;
		}
		timebetweenShot = 1/_swapper._activeItem.GetComponent<Weapon>().cadence;
		_timeShot -= 1.0 * Time.deltaTime;




		// SHOOT COMMAND

		if (Input.GetButton("Fire1") || (tirer == 10))
		{
			// Si le delais de la cadence est passe
			if (!_isOverheat && _timeShot <= 0.0) {
				print ("shoot");
				_timeShot = timebetweenShot;
				_shoot.CmdFire ();
				_POH.CmdHeat();
			}
		}

		// CAMERA CONTROL

		_controller.CmdUpdateCameraXY (Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

		if ( (cam_vertical == 10 ) )// up
				_controller.CmdUpdateCameraXY ((float)0.0, (float)0.15);

		if ( (cam_vertical == 20 ) ) // down
				_controller.CmdUpdateCameraXY ((float)0.0, (float)-0.15);

		if ( (cam_horizon == 10 ) )// gauche
				_controller.CmdUpdateCameraXY ((float)-0.5, (float)0.00);

		if ( (cam_horizon == 20 ) ) // droite
				_controller.CmdUpdateCameraXY ((float)0.5, (float)0.00);

		// MOVEMENT CONTROL

		int forward, right;

		if (Input.GetKey (KeyCode.Z) || (avancer == 10 ) ) {
			forward = 1;
			//anim.SetBool ("walk", true);
		} else if (Input.GetKey (KeyCode.S)) {
			forward = -1;
			//anim.SetBool ("walk", true);
		} else {
			forward = 0;
			//anim.SetBool("walk", false);
		}

		_controller.CmdUpdateForwardSpeed (forward);

		if (Input.GetKey (KeyCode.D) || (decaler == 10 )) {
			right = 1;
		} else if (Input.GetKey (KeyCode.Q) || (decaler == 20 ) ) {
			right = -1;
		} else {
			right = 0;
		}

		_controller.CmdUpdateStrafeSpeed (right);

		// WEAPON SWAP

		// For some reason, sending message "swap" with 0 as argument won't work,
		// because 0 is interpreted as null (╯°□°）╯︵ ┻━┻

    frame=(frame+1)%5;
    if ( frame == 0 )
    {
      changer = 1;
    }


    if ( changer_arme == 10 && changer == 1 )
    {
      armes=(armes+1)%3;
      changer = 0;
    }

		if(Input.GetKeyDown (KeyCode.Alpha1) || armes == 0 ){
			_swapper.CmdSwap (0);
			armes = 100;

			timebetweenShot = _swapper._activeItem.GetComponent<Weapon>().cadence;
		}
		if(Input.GetKeyDown (KeyCode.Alpha2) || armes == 1 ){
			_swapper.CmdSwap (1);
			armes = 100;

			timebetweenShot = _swapper._activeItem.GetComponent<Weapon>().cadence;
		}
		if(Input.GetKeyDown (KeyCode.Alpha3) || armes == 2 ){
			_swapper.CmdSwap (2);
			armes = 200;

			timebetweenShot = _swapper._activeItem.GetComponent<Weapon>().cadence;
		}
	}

	// Run the timer, return true if timer has ended
	bool HeatTimerFinished () {
		_heatTimer -= 1.0f * Time.deltaTime;
		return (_heatTimer <= 0);
	}

	// Start/Refresh the timer
	void StartHeatTimer () {
		_heatTimer = PlayerOverHeat.HEAT_COOLDOWN;
	}

	[ClientRpc]
	void RpcOnOverheat() {
		if (!isLocalPlayer)
			return;

		if (gameObject.GetComponent<PlayerOverHeat> ().currentHeat >= PlayerOverHeat.MAX_HEAT) {
			_isOverheat = true;
			StartHeatTimer ();
		}
	}
}
