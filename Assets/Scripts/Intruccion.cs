using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Intruccion : MonoBehaviour
{
    // Start is called before the first frame update
    private bool activar;
    private float timer;
    public GameObject video;
    public GameObject boton;
    bool unavez ;
    void Start()
    {

        activar = false;
        timer = 0;
        unavez=false;
    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
        if (timer > 4f && timer<4.5)
        {
            activar = true;
            unavez = true;
        }
        if (activar==true && unavez==true)
        {
            video.SetActive(true);
            boton.SetActive(true);
            unavez = false;

        }
    }
}
