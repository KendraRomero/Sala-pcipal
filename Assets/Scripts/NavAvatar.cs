using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavAvatar : MonoBehaviour
{

    void Start()
    {
    }

    void Update()
    {
        /*
        if (SceneManager.GetActiveScene().name != "SalaPcipal" && SceneManager.GetActiveScene().name != "Juego3" && SceneManager.GetActiveScene().name != "Juego1" && SceneManager.GetActiveScene().name != "Juego1_N2")
        {
            transform.gameObject.SetActive(false);
        }
        else
        {
            transform.gameObject.SetActive(true);
        }*/
    }

    private void Awake()
    {
        /*

        else if (SceneManager.GetActiveScene().name == "SalaPcipal" || SceneManager.GetActiveScene().name == "Juego3" || SceneManager.GetActiveScene().name == "Juego1" || SceneManager.GetActiveScene().name == "Juego1_N2")
        {
            transform.gameObject.SetActive(true);
        }

        if (SceneManager.GetActiveScene().name == "SalaPcipal")
        {
            transform.position = new Vector3(0f, 0f, -116.06f);
        }
        else if (SceneManager.GetActiveScene().name == "Juego1")
        {

            transform.position = new Vector3(10.634f, -1.037f, -7.1755f);
        }
        else if (SceneManager.GetActiveScene().name == "Juego1_N2")
        {
            transform.position = new Vector3(-0.59f, 0f, -12f);
        }
        else if (SceneManager.GetActiveScene().name == "Juego3")
        {

            transform.position = new Vector3(7.81f, 0f, -106.6f);
        }
        */
    }

}
