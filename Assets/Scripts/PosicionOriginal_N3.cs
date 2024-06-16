using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosicionOriginal_N3 : MonoBehaviour
{
    public GameObject eleccion;
    private Vector3[] manzanas = new Vector3[21];
    private Vector3[] manzanas_ang = new Vector3[21];
    private Vector3[] bananas = new Vector3[18];
    private Vector3[] bananas_ang = new Vector3[18];
    [SerializeField] public GameObject[] manzana = new GameObject[21];
    [SerializeField] public GameObject[] banana = new GameObject[18];
    ControlDelJuego1_N1 final;
    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i< manzana.Length ; i++)
        {
            manzanas[i] = manzana[i].transform.position;
            manzanas_ang[i] = manzana[i].transform.localEulerAngles;
        }
        for (int i = 0; i < banana.Length; i++)
        {
            bananas[i] = banana[i].transform.position;
            bananas_ang[i]= banana[i].transform.localEulerAngles;
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
        for (int i = 0; i < manzana.Length; i++)
        {
            manzana[i].transform.position = manzanas[i];
            manzana[i].transform.localEulerAngles = manzanas_ang[i];
        }
        for (int i = 0; i < banana.Length; i++)
        {
            banana[i].transform.position = bananas[i];
            banana[i].transform.localEulerAngles = bananas_ang[i];
        }
    }
}
