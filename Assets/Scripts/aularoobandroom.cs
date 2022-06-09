using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class aularoobandroom : MonoBehaviourPunCallbacks
{
    //Variaveis para Controlar os Textos na Unity.
    [Header("Variáveis Texto ")]
    [SerializeField]
    private Text NomeDaSala;

    [SerializeField]
    private Text qtd;
   


    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }


    void Update()
    {
        
    }


    public override void OnConnectedToMaster()
    {
        //Método para criar o nome do Player que irá entrar na sala/servidor.
       // PhotonNetwork.NickName = "Leonardo";

        Debug.Log("OnConnectedToMaster");
        //Método para entrar e criar alguma sala.
        //PhotonNetwork.JoinOrCreateRoom("Leonardo", null, null);

        //Método para entrar numa sala direto.
        //*PhotonNetwork.JoinRoom("TesteLeonardo");

        //Entrar numa sala qualquer.
        //PhotonNetwork.JoinLobby();

    }
    

    //Método de tentar achar uma sala randomicamente.
    public override void OnJoinedLobby()
    {
        Debug.Log("OnJoinedLobby");

        //Coamando para entrar em uma sala randomicamente.
        PhotonNetwork.JoinRandomRoom();
    }

    //Metodo de falha , no qual não conseguiu se conectar em alguma sala qualquer.
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("OnJoinRandomFailed");
        PhotonNetwork.CreateRoom("Teste");
    }

    public override void OnJoinedRoom()
    {
        //Método para saber se você está Logado na sala.
        Debug.Log("OnJoinedRoom");

        //Método para mostrar o nome da sala.
        NomeDaSala.text = "Nome da Sala : " + PhotonNetwork.CurrentRoom.Name;
        //Método para saber a quantidade jogadores na sala.
        qtd.text = "Quantidade : " + PhotonNetwork.CurrentRoom.PlayerCount;


        
    }

    //Método para mostrar que não se conectou , caso a sala não exista.
    
    
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("OnJoinRoomFailed" + message);
        
        //Método para criar a sala , caso ela não exista.
        PhotonNetwork.CreateRoom("TestLeonardo");

    }

    
    
    








}
