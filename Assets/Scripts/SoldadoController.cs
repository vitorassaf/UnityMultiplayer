using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;


public class SoldadoController : MonoBehaviourPunCallbacks
{
    [Header("Movimentação")]
    public float velocidadeCorrer;
    public float velocidadeRot;

    [Header("Câmera")]
    public Camera TerceiraPessoa;
    public Camera PrimeiraPessoa;
    public KeyCode btnCamera;

    Animator anim;

    //Componentes para Programar o Tiro.
    [Header("Arma")]
    public GameObject bala;
    public GameObject arma;
    public GameObject balaPview;//Componente Photon View.

    PhotonView photonView;

    [Header("Vida")]

    public float vidaInicial = 0f;
    public float vidaAtual;
    public Image PreencheVida;
    
    
    void Start()
    {
        //Pegar o Componente Animator
        anim = GetComponent<Animator>();
        photonView = GetComponent<PhotonView>();

        //Exclamação significa negação , ou seja ele vai destruir o que não é do Player.
        if (!photonView.IsMine)
        {
            Destroy(PrimeiraPessoa);
            Destroy(TerceiraPessoa);
        }

        PreencheVida.fillAmount = vidaInicial;
    }

   
    void Update()
    {
        //Se caso esses componentes forem de um player , só ele pode acessar , os outros players não.
        if (photonView.IsMine)
        {
            movimento();
            trocaCamera();
            Atirar();
        }

        if(Input.GetMouseButtonDown(0))
        {
            vidaManager(0.1f);
        }
        
    }


    public void tiraVida(float valor)
    {
        photonView.RPC("vidaManager", RpcTarget.AllBuffered, valor);//Guarda as Informações no Servidor.
    }

    [PunRPC]
    void vidaManager(float valor)
    {
        //Agrega um Valor a vidaAtual;
        vidaAtual += valor;
        PreencheVida.fillAmount = vidaAtual;
    }

    public void Atirar()
    {
        //Acessando o Componente do Mouse.
        //Zero Botão esquerdo e um botão direiro.
        //Esse metodo vai dispara enquanto o Jogador Apertar o botão.
        if(Input.GetMouseButtonDown(0))
        {
            //Quando colocamos um Prefab , colocamos o Metodo Instantiate , com isso ele vai instaciar o objeto bala na posiçaõ do Dispara e Rotação do Disparo
            //Instantiate(bala, arma.transform.position, arma.transform.rotation);

            //Vai instanciar a bala que tem o Componente Photon View.
            PhotonNetwork.Instantiate(balaPview.name, arma.transform.position, arma.transform.rotation);

            if(Input.GetMouseButtonDown(1))
            {
                photonView.RPC("Atirando", RpcTarget.All);//Está chamando um Evento Remotamente 
            }
        }

    }
    
    //Existe dois jogo single Player, mas a chamada do PunRPC , faz com que o jogo pareça o mesmo .
    [PunRPC]
    void Atirando()
    {
        //Está instanciando uma bala single player.
        Instantiate(bala, arma.transform.position, arma.transform.rotation);
    }

    public void movimento()
    {

        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        if(vertical > 0)
        {
            //Vai Disparar a Animação de Andar.
            anim.SetBool("podeAndar", true);
       
        }
        else
        {
            //Não vai Disparar a Aniamação de Andar
            anim.SetBool("podeAndar", false);
            
        }

        //Movimentação de Jogador.
        transform.Translate(new Vector3(0, 0, vertical * velocidadeCorrer * Time.deltaTime));

        //Rotação do Personagem em Graus.
        transform.Rotate(new Vector3(0, horizontal * velocidadeRot));

     
    }

    public void trocaCamera()
    {
        if(Input.GetKeyDown(btnCamera))
        {
            if(PrimeiraPessoa.depth == 0)
            {
                PrimeiraPessoa.depth = 1;
                TerceiraPessoa.depth = 0;
            }

            else
            {
                PrimeiraPessoa.depth = 0;
                TerceiraPessoa.depth = 1;
            }
        }
    }

    
 


}
