using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class nickName : MonoBehaviour
{
    // Start is called before the first frame update


    //Criando a variável do componente.
    public InputField nameField;
    

    //Criando a variavel do tipo string para receber o Nome do Personagem.
    private string charName;


    public void nick_Name()
    {
        //Método para setar o nome do player no componente InputField.

        charName = nameField.text;


        //Exibição do Nome do Player do Debugger;

        Debug.Log("Nome do Player é : " + charName);
    }

    public void Mudar_Cena()
    {
        SceneManager.LoadScene("Salas");
    }
}
