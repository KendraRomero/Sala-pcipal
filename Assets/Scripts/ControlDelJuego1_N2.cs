using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class ControlDelJuego1_N2 : MonoBehaviour
{
   [SerializeField] private TMP_Text textTimer;
   [SerializeField, Tooltip("Tiempo en segundos")] public float timer;
    public cajagalletascript cajagalle;
    public cajadonascript cajadon;
    public TextMeshProUGUI textoGalletaMarcador;
    public TextMeshProUGUI textoDonaMarcador;
    public TextMeshProUGUI textofinTiempo;
    public TextMeshProUGUI textoResultadoIncorrecto1;
    public TextMeshProUGUI textoResultadoIncorrecto2;
    public TextMeshProUGUI textoResultadoCorrecto;
    public TextMeshProUGUI textoCorrecto;
    public TextMeshProUGUI textoInorrecto;
    public GameObject picolaboR;
    public GameObject botonPlay;
    public GameObject eleccion;
    private int galletaInter;
    private int donaInter;
    public Button BotonOpcA;
    public Button BotonOpcB;
    public Button BotonOpcC;
    private int minutos;
    private int segundos;
    private int cent;
    private int total1;
    private int total2;
    private int total;
    public float timerNivel;
    private bool flag;
    public bool fin;

    void Start()
    {
        timerNivel = 0.0f;
        timer = 60;
        flag = false;
        textoCorrecto.gameObject.SetActive(false);
        textoInorrecto.gameObject.SetActive(false);
        textofinTiempo.gameObject.SetActive(false);
        BotonOpcA.gameObject.SetActive(false);
        BotonOpcB.gameObject.SetActive(false);
        BotonOpcC.gameObject.SetActive(false);
        fin = false;
        galletaInter = 0;
        donaInter = 0;

    }

    void Update()
    {
        if (botonPlay.activeSelf == false && picolaboR.activeSelf == false && eleccion.activeSelf == false)
        {
            Actualizartiempo();
        }

    }
    public void ActualizarGalletas(int galletatotal)
    {
        textoGalletaMarcador.text = "Galletas: " + galletatotal;
    }

    public void ActualizarDonas(int donatotal)
    {
        textoDonaMarcador.text = "Donuts: " + donatotal;
    }



    public void FinTiempo(int total, int total1, int total2, int galletaInter, int donaInter)
    {
        if (0 >= total2)
        {
            textofinTiempo.text = "¡No se han recolectado Galletas ni Donuts!";
            textofinTiempo.gameObject.SetActive(true);
            timerNivel += Time.deltaTime;
            if (timerNivel > 1f)
            {
                Start();
                ActualizarGalletas(galletaInter);
                ActualizarDonas(donaInter);
                eleccion.SetActive(true);
            }
        }
        else if (total2 > 0 && flag == false)
        {
            if (galletaInter > donaInter)
            {
                textofinTiempo.text = "¡Es turno de la resta!\nResta el número de galletas y donas que marcan las cajas y pulsa la respuesta correcta: " + galletaInter + " - " + donaInter;

            }
            else
            {
                textofinTiempo.text = "¡Es turno de la resta!\nResta el número de donuts y galletas que marcan las cajas y pulsa la respuesta correcta: " + donaInter + " - " + galletaInter;

            }
            textoResultadoIncorrecto1.text = total1.ToString();
            textoResultadoIncorrecto2.text = total2.ToString();
            textoResultadoCorrecto.text = total.ToString();
            textofinTiempo.gameObject.SetActive(true);
            BotonOpcA.gameObject.SetActive(true);
            BotonOpcB.gameObject.SetActive(true);
            BotonOpcC.gameObject.SetActive(true);
            FindObjectOfType<AudioManager>().Oneshot("FinTiempo");
            flag = true;
        }
        if (textoCorrecto.gameObject.activeSelf == true || textoInorrecto.gameObject.activeSelf == true)
        {
            timerNivel += Time.deltaTime;
            fin = true;
            if (timerNivel > 1f)
            {
                Start();
                eleccion.SetActive(true);

            }
        }
    }
    void Actualizartiempo()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = 0;
        }
        if (timer != 0)
        {
            minutos = (int)(timer / 60f);
            segundos = (int)(timer - minutos * 60f);
            cent = (int)((timer - (int)timer) * 100f);
            textTimer.text = string.Format("{0:00}:{1:00}:{2:00}", minutos, segundos, cent);
            //Nivel 2
            galletaInter = cajagalle.contadorgalleta;
            ActualizarGalletas(galletaInter);
            donaInter = cajadon.contadordona;
            ActualizarDonas(donaInter);
            total1 = Mathf.Abs(galletaInter - donaInter + 1);
            total2 = Mathf.Abs(galletaInter - donaInter - 1);
            total = Mathf.Abs(galletaInter - donaInter);

        }
        else if (timer == 0)
        {
            textTimer.text = string.Format("{0:00}:{1:00}:{2:00}", 0, 0, 0);
            FinTiempo(total, total1, total2, galletaInter, donaInter);
        }
    }

}
