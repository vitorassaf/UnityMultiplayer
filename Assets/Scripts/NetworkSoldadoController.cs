using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkSoldadoController : MonoBehaviourPunCallbacks
{

    [SerializeField]
    GameObject soldado;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

 
    void Update()
    {
        
    }

    public override void OnConnectedToMaster()
    {
        //Criando o Nome do Lobby
        TypedLobby t = new TypedLobby("LobbyProfessor", LobbyType.Default);
        PhotonNetwork.JoinLobby(t);
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("OnJoinedLobby");
        //Nome do Lobby
        Debug.Log("Nome Lobby : " + PhotonNetwork.CurrentLobby.Name);
        PhotonNetwork.JoinOrCreateRoom("SalaProfessor", null, null);
        
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom");

        //Vai Instanciar o Prefab do Soldado, de acordo com a posição e rotação original do Player.
        PhotonNetwork.Instantiate(soldado.name, soldado.transform.position, soldado.transform.rotation, 0);

    }


}
