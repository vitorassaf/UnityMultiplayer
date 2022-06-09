using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class Menu : MonoBehaviourPunCallbacks
{




    // Start is called before the first frame update
    void Start()
    {
        //Conexão com o Servidor Criado no Site da Photon.

        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame

    public void ConectarAutomaticamente()
    {
        PhotonNetwork.ConnectUsingSettings();
        OnConnectedToMaster();
        Debug.Log("OnConnectedToMaster");
        PhotonNetwork.ConnectToRegion("sa");
        Debug.Log("Region : " + PhotonNetwork.CloudRegion);
        Debug.Log("Ping : " + PhotonNetwork.GetPing());
    }

    public void Conectar_Euro()
    {
        PhotonNetwork.ConnectUsingSettings();
        OnConnectedToMaster();
        Debug.Log("OnConnectedToMaster");
        PhotonNetwork.ConnectToRegion("eu");
        Debug.Log("Region : " + PhotonNetwork.CloudRegion);
        Debug.Log("Ping : " + PhotonNetwork.GetPing());
    }

    public void Conectar_India()
    {
        PhotonNetwork.ConnectUsingSettings();
        OnConnectedToMaster();
        Debug.Log("OnConnectedToMaster");
        PhotonNetwork.ConnectToRegion("in");
        Debug.Log("Region : " + PhotonNetwork.CloudRegion);
        Debug.Log("Ping : " + PhotonNetwork.GetPing());
    }

    public void Conectar_Japan()
    {
        PhotonNetwork.ConnectUsingSettings();
        OnConnectedToMaster();
        Debug.Log("OnConnectedToMaster");
        PhotonNetwork.ConnectToRegion("jp");
        Debug.Log("Region : " + PhotonNetwork.CloudRegion);
        Debug.Log("Ping : " + PhotonNetwork.GetPing());
    }

    public void Desconectar_Servidor()
    {
        PhotonNetwork.Disconnect();
        Debug.Log("Você foi Desconectado do Servidor ! ");

    }






}
