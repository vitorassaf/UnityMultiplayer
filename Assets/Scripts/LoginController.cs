using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LoginController : MonoBehaviourPunCallbacks
{
    public InputField txtNome;
    public GameObject Login;
    public GameObject Configuracao;
    public InputField txtNomeSala;

    public bool procuraSala = false;

    



    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void Entrar()
    {
        //O Nome do Player vai receber o Input de texto do Login.
        PhotonNetwork.NickName = txtNome.text;

        //O Painel Login é começa com false , pois na Unity ele é o primeiro painel , então para o configuração ser true , o painel login recebe o comando false.
        Login.SetActive(false);
        Configuracao.SetActive(true);
    }

    public void BuscarSala()
    {
        //Essa variavel recebe true pois está tentando entrar numa sala e não criando uma sala.
        procuraSala = true;

        //Comando para fazer relação com o servidor criado no Site da Photon.
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        Debug.Log("OnConnectedToMaster");
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("OnJoinedLobby");

        if(procuraSala)
        {
            //Automaticamente!!!

            //Irá Tentar Entrar em uma sala Randomica , se a condição for verdadeira.
            PhotonNetwork.JoinRandomRoom();
        }

        else
        {
            //Por Nome da Sala

            //Se a condição for falsa , ele vai criar uma sala , cujo o nome foi digitado no campo de texto no painel de configuração.
            PhotonNetwork.CreateRoom(txtNomeSala.text);
        }

        
    }

    public override void OnJoinedRoom()
    {
        //Irá Mostrar o nome da sala.
        Debug.Log("Sala: " + PhotonNetwork.CurrentRoom.Name);
        Debug.Log("Quantidade de Players: " + PhotonNetwork.CurrentRoom.PlayerCount);

    }

    public void Criar()
    {
        //a variavel booleana recebe o valor falso , pois já não está mais procurando uma sala e sim criando uma.
        procuraSala = false;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("OnJoinRandomFailed");

        PhotonNetwork.CreateRoom("salaLeonardo");

    }

    public void  ButtonCena(string cena)
    {
        SceneManager.LoadScene(cena);
    }
}
