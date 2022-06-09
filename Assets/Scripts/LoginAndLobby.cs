using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;


public class LoginAndLobby : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Text nome_sala;
    

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        print("OnConnectedToMaster");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        print("OnJoinedLobby");

        PhotonNetwork.JoinRandomRoom();

    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("OnJoinRandomFailed");
      
    }

    public override void OnJoinedRoom()
    {
        print("OnJoinedRoom");


        nome_sala.text = "Nome da Sala : " + PhotonNetwork.CurrentRoom.Name;

    }

   public void Create_Room()
    {
        PhotonNetwork.CreateRoom("Teste");
    }

    

}

    





