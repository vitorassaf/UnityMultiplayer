using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class NetWorkController : MonoBehaviourPunCallbacks
{
   float tempo = 0;

   bool conectado = true;

    
    
    void Start()
    {
        //Conexão com o Servidor Criado no Site.
        PhotonNetwork.ConnectUsingSettings();
        //Método como trocar de Região.
       // PhotonNetwork.ConnectToRegion("asia");
    }

   
    void Update()
    {
        //Método para Desconectar um servidor e automaticamente conectar a outro instantaneamente.
        tempo += Time.deltaTime;
        if(tempo >=3 && conectado)
        {
            PhotonNetwork.Disconnect();
            conectado = false;
            
        
        }
    }
    
    //Para chamar algum método do photon , escreva override.
    //Verificação se a Conexão vai Funcionar , por isso usamos o método da Pun.
    public override void OnConnected()
    {
        
        Debug.Log("OnConnected");
    }
    public override void OnConnectedToMaster()
    {
        //Método Para saber se estou Autenticado no Servidor
        Debug.Log("OnConnectedToMaster");
        //Método para saber a região onde estou Conectado.
        Debug.Log("Região : " + PhotonNetwork.CloudRegion);
        //Método para saber a Latência do Servidor.
        Debug.Log("Ping : " + PhotonNetwork.GetPing());
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("OnDisconnected");
        PhotonNetwork.ConnectToRegion("jp");
    }
    


}
