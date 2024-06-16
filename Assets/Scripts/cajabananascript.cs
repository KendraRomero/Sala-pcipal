using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cajabananascript : MonoBehaviour
{

    // Start is called before the first frame update
    public int contadorbanana;
    public GameObject eleccion;
    public GameObject botonplay;
    public GameObject textofintiempo;
    void Start()
    {
        contadorbanana = 0;
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
        if (collision.gameObject.tag == "Banana")
        {
            contadorbanana++;
            FindObjectOfType<AudioManager>().Oneshot("win");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Banana"))
        {
            contadorbanana--;
            if ( eleccion.activeSelf != true && textofintiempo.activeSelf != true)
            {
                FindObjectOfType<AudioManager>().Oneshot("error");
            }
        }
    }
}
