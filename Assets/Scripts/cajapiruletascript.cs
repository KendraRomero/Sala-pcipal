using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cajapiruletascript : MonoBehaviour
{
    public int contadorpiruleta;
    public GameObject eleccion;
    public GameObject textofintiempo;
    public GameObject botonplay;
    public ControlDelJuego1_N1 control;
    void Start()
    {
        contadorpiruleta = 0;
    }
    void Update()
    {
        if (eleccion.activeSelf==true )
        {
            contadorpiruleta = 0;
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Piruleta"))
        {
            contadorpiruleta++;
            FindObjectOfType<AudioManager>().Oneshot("win");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Piruleta"))
        {
            contadorpiruleta--;
            if (control.fin !=true && eleccion.activeSelf != true && control.timer !=0f && textofintiempo.activeSelf!=true )
            {
                FindObjectOfType<AudioManager>().Oneshot("error");
            }
        }
    }
}
