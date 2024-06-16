using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class botonCambioEscena : MonoBehaviour
{
  
    public void SalaPrincipal()
    {
        SceneManager.LoadScene("SalaPcipal");
    }
    public void Juego1()
    {
        SceneManager.LoadScene("Juego1");
    }

    public void Juego3()
    {
        SceneManager.LoadScene("Juego3");
    }

    /*public void Pararmusica()
    {
        FindObjectOfType<AudioManager>().Stop("kid");
    }*/
}

