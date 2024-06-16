using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cajamanzanascript : MonoBehaviour
{

    // Start is called before the first frame update
    public int contadormanzana;
    public GameObject eleccion;
    public GameObject botonplay;
    public GameObject textofintiempo;

    void Start()
    {
        contadormanzana = 0;
    }


    // Update is called once per frame
    void Update()
    {
        if (eleccion.activeSelf==true )
        {
            contadormanzana = 0;
        }

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Manzana"))
        {
            contadormanzana++;
            FindObjectOfType<AudioManager>().Oneshot("win");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Manzana"))
        {
            contadormanzana--;
            if (  eleccion.activeSelf != true && textofintiempo.activeSelf != true)
            {
                FindObjectOfType<AudioManager>().Oneshot("error");
            }
        }
    }
}
