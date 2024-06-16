using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cajadonascript : MonoBehaviour
{

    // Start is called before the first frame update
    public int contadordona;
    public GameObject eleccion;
    public GameObject botonplay;
    public GameObject textofintiempo;
    void Start()
    {
        contadordona = 0;
    }

    void Update()
    {
        if (eleccion.activeSelf == true )
        {
            Start();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Dona"))
        {
            contadordona++;
            FindObjectOfType<AudioManager>().Oneshot("win");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Dona"))
        {
            contadordona--;
            if ( eleccion.activeSelf != true  && textofintiempo.activeSelf != true)
            {
                FindObjectOfType<AudioManager>().Oneshot("error");
            }

        }
    }

}
