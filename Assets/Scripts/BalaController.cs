using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BalaController : MonoBehaviour
{
    public float forca;
    Rigidbody rb;

    void Start()
    {
        //Acessando o Componente Rigidbody.
        rb = GetComponent<Rigidbody>();
        
    }

    
    void Update()
    {
        //Adicionando uma Força para a bala e destruindo ela depois de 4 Segundos.
        rb.AddForce(transform.forward * forca, ForceMode.Force);
        Destroy(gameObject, 4);
    }

   
    void OnTriggerEnter(Collider other)
    {
        
        if(other.CompareTag("Player") && other.GetComponent<PhotonView>().IsMine)
        {
            other.GetComponent<SoldadoController>().tiraVida(0.1f);

        }
    }

    
    
}
