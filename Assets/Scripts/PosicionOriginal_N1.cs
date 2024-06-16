using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosicionOriginal_N1 : MonoBehaviour
{
    public GameObject eleccion;
    private Vector3[] magdalenas = new Vector3[21];
    private Vector3[] magdalenas_ang = new Vector3[21];
    private Vector3[] piruletas = new Vector3[18];
    private Vector3[] piruletas_ang = new Vector3[18];
    [SerializeField] public GameObject[] magdalena = new GameObject[21];
    [SerializeField] public GameObject[] piruleta = new GameObject[18];
    ControlDelJuego1_N1 final;
    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i< magdalena.Length ; i++)
        {
            magdalenas[i] = magdalena[i].transform.position;
            magdalenas_ang[i] = magdalena[i].transform.localEulerAngles;
        }
        for (int i = 0; i < piruleta.Length; i++)
        {
            piruletas[i] = piruleta[i].transform.position;
            piruletas_ang[i]= piruleta[i].transform.localEulerAngles;
        }
    }
    void Update()
    {
        
        if (eleccion.activeSelf==true )
        {
            ActualizarPosicionOiriginal();
        }
    }
    private void Awake()
    {
        
    }
    void ActualizarPosicionOiriginal()
    {
        for (int i = 0; i < magdalena.Length; i++)
        {
            magdalena[i].transform.position = magdalenas[i];
            magdalena[i].transform.localEulerAngles = magdalenas_ang[i];
        }
        for (int i = 0; i < piruleta.Length; i++)
        {
            piruleta[i].transform.position = piruletas[i];
            piruleta[i].transform.localEulerAngles = piruletas_ang[i];
        }
    }
}
