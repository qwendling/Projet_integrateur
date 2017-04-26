
using UnityEngine;
using UnityEngine.Networking;



public class ClientConnetion : MonoBehaviour {

    public NetworkManager m_Manager;

    // Use this for initialization
    void Start () {
        m_Manager.StartClient();
    }
	
	// Update is called once per frame
	void Update () {

        if ( !NetworkClient.active && Input.GetKeyDown(KeyCode.S))
        { 
            m_Manager.StartClient();
        }

        if ( NetworkClient.active && Input.GetKeyDown(KeyCode.X))
        {
            m_Manager.StopClient();
        }
       

    }
}
