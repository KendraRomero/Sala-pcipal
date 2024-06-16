using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosicionOriginal_N2 : MonoBehaviour
{
    public GameObject eleccion;
    private Vector3[] donuts = new Vector3[15];
    private Vector3[] donuts_ang = new Vector3[15];
    private Vector3[] galletas2 = new Vector3[26];
    private Vector3[] galletas_ang2 = new Vector3[26];
    private Vector3[] galletas = new Vector3[6];
    private Vector3[] galletas_ang = new Vector3[6];
    private Vector3[] piruletas = new Vector3[8];
    private Vector3[] piruletas_ang = new Vector3[8];
    [SerializeField] public GameObject[] donut = new GameObject[15];
    [SerializeField] public GameObject[] galleta = new GameObject[26];
    [SerializeField] public GameObject[] galleta2 = new GameObject[6];
    [SerializeField] public GameObject[] piruleta = new GameObject[8];
    ControlDelJuego1_N1 final;
    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i< donut.Length ; i++)
        {
            donuts[i] = donut[i].transform.position;
            donuts_ang[i] = donut[i].transform.localEulerAngles;
        }
        for (int i = 0; i < galleta2.Length; i++)
        {
            galletas2[i] = galleta2[i].transform.position;
            galletas_ang2[i] = galleta2[i].transform.localEulerAngles;
        }
        for (int i = 0; i < galleta.Length; i++)
        {
            galletas[i] = galleta[i].transform.position;
            galletas_ang[i]= galleta[i].transform.localEulerAngles;
        }
        for (int i = 0; i < piruleta.Length; i++)
        {
            piruletas[i] = piruleta[i].transform.position;
            piruletas_ang[i] = piruleta[i].transform.localEulerAngles;
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
        for (int i = 0; i < donut.Length; i++)
        {
            donut[i].transform.position = donuts[i];
            donut[i].transform.localEulerAngles = donuts_ang[i];
        }
        for (int i = 0; i < galleta2.Length; i++)
        {
            galleta2[i].transform.position = galletas2[i];
            galleta2[i].transform.localEulerAngles = galletas_ang2[i];
        }
        for (int i = 0; i < galleta.Length; i++)
        {
            galleta[i].transform.position = galletas[i];
            galleta[i].transform.localEulerAngles = galletas_ang[i];
        }
        for (int i = 0; i < piruleta.Length; i++)
        {
            piruleta[i].transform.position = piruletas[i];
            piruleta[i].transform.localEulerAngles = piruletas_ang[i];
        }
    }
}
