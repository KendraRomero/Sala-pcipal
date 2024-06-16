using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class ControlDelJuego1_N3 : MonoBehaviour
{
   [SerializeField] private TMP_Text textTimer;
   [SerializeField, Tooltip("Tiempo en segundos")] public float timer;
    public  cajamanzanascript cajamanzana;
    public cajabananascript cajabanana;
    public TextMeshProUGUI textomanzanaMarcador;
    public TextMeshProUGUI textobananaMarcador;
    public TextMeshProUGUI textofinTiempo;
    public TextMeshProUGUI textoResultadoIncorrecto1;
    public TextMeshProUGUI textoResultadoIncorrecto2;
    public TextMeshProUGUI textoResultadoCorrecto;
    public TextMeshProUGUI textoCorrecto;
    public TextMeshProUGUI textoInorrecto;
    public GameObject picolaboR;
    public GameObject botonPlay;
    public GameObject eleccion;
    private int bananaInter;
    private int manzanaInter;
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
        manzanaInter = 0;
        bananaInter = 0;

    }
    void Update()
    {
        if (botonPlay.activeSelf == false && picolaboR.activeSelf == false  && eleccion.activeSelf==false)
        {
            Actualizartiempo();
        }

    }
    public void Actualizarmanzanas( int manzanatotal)
    {
        textomanzanaMarcador.text = "Manzanas: " + manzanatotal;
    }

    public void Actualizarbananas(int bananatotal)
    {
        textobananaMarcador.text = "Bananas: " + bananatotal;
    }

    public void FinTiempo(int total, int total1, int total2, int manzanatotal, int bananatotal)
    {
        if (bananaInter == 0 && manzanaInter==0)
        {
            textofinTiempo.text = "¡No se han recolectado suficientes manzanas ni bananas!";
            textofinTiempo.gameObject.SetActive(true);
            timerNivel += Time.deltaTime;
            if (timerNivel > 1f)
            {
                Start();
                eleccion.SetActive(true);
            }
        }
        else if (bananaInter != 0 && manzanaInter != 0 && flag==false)
        {
            textofinTiempo.text= "¡Es turno de la multiplicación!\nMultiplica el número de bananas y manzanas que marcan las cajas y pulsa la respuesta correcta: " + manzanatotal  + " x " + bananatotal;
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
        if (textoCorrecto.gameObject.activeSelf==true || textoInorrecto.gameObject.activeSelf == true)
        {
            timerNivel += Time.deltaTime;
            fin = true;
            if (timerNivel > 1f)
            {
                Start();
                Actualizarmanzanas(manzanaInter);
                Actualizarbananas(bananaInter);
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
            manzanaInter = cajamanzana.contadormanzana;
            Actualizarmanzanas(manzanaInter);
            bananaInter = cajabanana.contadorbanana;
            Actualizarbananas(bananaInter);
            total1 = (bananaInter * manzanaInter) - 1;
            total2 = (bananaInter * manzanaInter) + 2;
            total = bananaInter * manzanaInter;
        }
        else if (timer == 0 )
        {
            FinTiempo(total, total1, total2, manzanaInter, bananaInter);
            textTimer.text = string.Format("{0:00}:{1:00}:{2:00}", 0, 0, 0);
            
        }
    }
}
