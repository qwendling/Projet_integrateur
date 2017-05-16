<<<<<<< HEAD
﻿
using UnityEngine;
using UnityEngine.Networking;



public class ServerConnection : MonoBehaviour
{

    public NetworkManager m_Manager;

    // Use this for initialization
    void Start()
    {
        m_Manager.StartServer();
    }

    // Update is called once per frame
    void Update()
    {

        if (!NetworkServer.active && Input.GetKeyDown(KeyCode.S))
        {
            m_Manager.StartServer();
        }

        if (NetworkClient.active && Input.GetKeyDown(KeyCode.X))
        {
            m_Manager.StopServer();
        }


    }
}
=======
﻿
using UnityEngine;
using UnityEngine.Networking;



public class ServerConnection : MonoBehaviour
{

    public NetworkManager m_Manager;

    // Use this for initialization
    void Start()
    {
        m_Manager.StartServer();
    }

    // Update is called once per frame
    void Update()
    {

        if (!NetworkServer.active && Input.GetKeyDown(KeyCode.S))
        {
            m_Manager.StartServer();
        }

        if (NetworkClient.active && Input.GetKeyDown(KeyCode.X))
        {
            m_Manager.StopServer();
        }


    }
}
>>>>>>> origin/master
