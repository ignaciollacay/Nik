using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class NetworkServer : NetworkBehaviour
{
    private bool isConnected = false;
    private ulong clientID;

    private void Start()
    {
        //NetworkManager.Singleton.StartServer();
    }

    public void ConnectPlayer()
    {
        if (!isConnected)
        {
            isConnected = true;
            NetworkManager.Singleton.StartClient();
            clientID = OwnerClientId;
        }
    }
    public void DisconnectPlayer()
    {
        if (isConnected)
        {
            isConnected = false;
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.H))
        {
            NetworkManager.Singleton.StartHost();
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            //Application.Quit();
        }
        if (Input.GetKey(KeyCode.Return))
        {
            ConnectPlayer();
        }
        if (Input.GetKey(KeyCode.Backspace))
        {
            DisconnectPlayer();
        }
    }
}