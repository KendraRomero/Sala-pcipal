using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjetoEnArea : MonoBehaviour
{

    public GameObject objetoCentral;
    public BoxCollider objetoCollider;
    private float ancho;
    private float largo;
    private float alto;

    private Vector3 posicionCentral;

    private int i; //numero de numeros 
    private int[] vectorNum;
    private int suma;

    void Start()
    {
        // variables para cuentas
        i = 0;
        suma = 0;
        vectorNum = new int[10];

        //variables de posicion de objetos
        posicionCentral = objetoCentral.transform.position;
        ancho = objetoCollider.size.x;
        largo = objetoCollider.size.y;
        alto = objetoCollider.size.z;
    }

    // Funcion de si entra algo en el cuadrado //
    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("ok ontrigger enter");
        // Check if the entering object is within the 3D rectangle
        if (CheckObjectsInsideRectangle(collider.transform.position) == true)
        {
            Debug.Log("ok insiderectangle");
            sumaObjetosArea(true, collider);
        }
    }

    // Funcion de si sale algo del cuadrado //
    private void OnTriggerExit(Collider collider)
    {
        Debug.Log("ok ontrigger exit");
        // Check if the exiting object was inside the 3D rectangle
        if (CheckObjectsInsideRectangle(collider.transform.position) == false)
        {
            sumaObjetosArea(false, collider);
        }
    }

    private void sumaObjetosArea(bool isuma, Collider collider)
    {
        // si es suma
        if(isuma == true) 
        {
            Debug.Log("suma");

            //** FUNCION DE SUMA **//

            suma = 0;
 
            vectorNum[i] = int.Parse(collider.gameObject.tag);

            for (int a = 0; a <= i; a++)
            {
                suma += vectorNum[a];
            }

            i++;
        }

        // si es resta
        else if (isuma == false)
        {
            Debug.Log("resta");
            //** FUNCION DE RESTA **//

            int a = 0;

            for (a = 0; a <= i - 1; a++)
            {
                if (vectorNum[a] == int.Parse(collider.gameObject.tag))
                {
                    Debug.Log("num encontrado");
                    // Retroceder los valores en la posición dada
                    for (int b = a; b <= i - 2; b++)
                    {
                        vectorNum[b] = vectorNum[b + 1];
                    }
            

                    // hacemos los calculos quitando el numero que hemos quitado
                    i--;

                    for (int c = 0; c <= i; c++)
                    {
                        suma += vectorNum[c];
                    }

                    return;

                }
            }

        }
    }

    bool CheckObjectsInsideRectangle(Vector3 position)
    {
        float medioAncho = ancho / 2f;
        float medioLargo = largo / 2f;
        float medioAlto = alto / 2f;

        // distancia entre el objeto central y el collider que entra/sale
        float deltaX = Mathf.Abs(position.x - posicionCentral.x);
        float deltaY = Mathf.Abs(position.y - posicionCentral.y);
        float deltaZ = Mathf.Abs(position.z - posicionCentral.z);

        Debug.Log(" ( " + medioAncho + " , " + medioLargo + " , " + medioAlto + " ) " + " ( " + deltaX + " , " + deltaY + " , " + deltaZ + " ) ");

        if (deltaX <= medioAncho && deltaY <= medioLargo && deltaZ <= medioAlto) {
            return true;
        }
        else return false;
    }


    public int[] vectNumeros
    {
        get
        {
            return vectorNum;
        }
    }

    public int numPecesIn
    {
        get
        {
            return i;
        }
    }

    public int sumaTot
    {
        get
        {
            return suma;
        }
    }
}
