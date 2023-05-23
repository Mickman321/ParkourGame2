using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class LobbyController : MonoBehaviourPunCallbacks
{ // Den här koden controllerar storleken på rummet  skapar och letar också efter ett rum/server alla spelare hamnar på.

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

    public void CreateRoom()
    {
        print("creating room");

        int randomRoomNumber = Random.Range(0, 100000);

        print(randomRoomNumber);

        RoomOptions options = new RoomOptions()
        {

            IsVisible = true,
            IsOpen = true,
            MaxPlayers = (byte)roomSize
        };

        PhotonNetwork.CreateRoom("Room" + randomRoomNumber, options);
    }

    

        public override void OnCreateRoomFailed(short returnCode, string message) 
        {

         CreateRoom();

        }

        public void Cancel()
        {

         PhotonNetwork.LeaveRoom();
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
