using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cajagalletascript : MonoBehaviour
{

    // Start is called before the first frame update
    public int contadorgalleta;
    public GameObject eleccion;
    public GameObject botonplay;
    public GameObject textofintiempo;
    void Start()
    {
        contadorgalleta = 0;
    }


    // Update is called once per frame
    void Update()
    {
        if (eleccion.activeSelf == true)
        {
            Start();
        }

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Galleta")
        {
            contadorgalleta++;
            FindObjectOfType<AudioManager>().Oneshot("win");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Galleta"))
        {
            contadorgalleta--;
            if ( eleccion.activeSelf != true   && textofintiempo.activeSelf != true)
            {
                FindObjectOfType<AudioManager>().Oneshot("error");
            }

        }
    }
}
