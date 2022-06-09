using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class CenaTEste : MonoBehaviourPunCallbacks
{
    public bool conectado;
    
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Conexão com Êxito !!1 ");

        conectado = true;
    }

    public void ConectadoMultiplayer()
    {

        PhotonNetwork.ConnectUsingSettings();
        OnConnectedToMaster();
        if(conectado==true)
        {
            SceneManager.LoadScene("CenaJogo");
        }

        else
        {
            Debug.Log("Não foi possivel conectar no servidor !!! ");
        }
    }


}
