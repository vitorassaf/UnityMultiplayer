using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using System.Runtime.InteropServices.WindowsRuntime;

public class Button_Criar : MonoBehaviourPunCallbacks
{

    [SerializeField]
    private Text _roomName;
    private Text RoomName
    {
        get { return _roomName; }
    }

    public override void OnConnectedToMaster()
    {
        print("OnConnectedToMaster");

        
    }

    public override void OnJoinedLobby()
    {
        print("OnJoinedLobby");
    }



    public void OnClick_Create_Room()
    {
        if(PhotonNetwork.CreateRoom(RoomName.text))
        {
            print("Criando Sala com Sucesso !!! ");
        }

        else
        {
            print("Criando Sala sem Sucesso !! ");
        }
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        print("Falha na Criação da Sala " + message);
    }

    public override void OnCreatedRoom()
    {
        print("Sala Criada com Sucesso !! ");
    }
}

    
