using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class LobbyController : MonoBehaviourPunCallbacks
{

    public int roomSize;

    public void JoinRoom()
    {
        PhotonNetwork.JoinRandomRoom();

        print("trying to join");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        print("can't find room");
        CreateRoom();
    }

    void CreateRoom()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
