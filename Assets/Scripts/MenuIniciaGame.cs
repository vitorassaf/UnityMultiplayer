using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuIniciaGame : MonoBehaviour
{

    

    void CenaJogo(string cena)
    {
        SceneManager.LoadScene(cena);
    }
}
