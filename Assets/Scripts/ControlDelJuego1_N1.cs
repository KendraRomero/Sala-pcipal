using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public class ControlDelJuego1_N1 : MonoBehaviour
{
   [SerializeField] private TMP_Text textTimer;
   [SerializeField, Tooltip("Tiempo en segundos")] private float timer;

    //Nivel 1
    public  cajacupcakescript cajacup;
    public cajapiruletascript cajapiru;
    public TextMeshProUGUI textoMagdalenaMarcador;
    public TextMeshProUGUI textoPiruletaMarcador;
    public TextMeshProUGUI textofinTiempo;
    public TextMeshProUGUI textoResultadoIncorrecto1;
    public TextMeshProUGUI textoResultadoIncorrecto2;
    public TextMeshProUGUI textoResultadoCorrecto;
    public TextMeshProUGUI textoCorrecto;
    public TextMeshProUGUI textoInorrecto;
    private int piruletaInter;
    private int magdalenaInter;


    //Generic
    public Button BotonOpcA;
    public Button BotonOpcB;
    public Button BotonOpcC;
    public TextMeshProUGUI textoPocosObjetosRecolectados;
    public bool tiempoActivo;
    private int minutos;
    private int segundos;
    private int cent;
    private int total1;
    private int total2;
    private int total;


    // Start is called before the first frame update
    void Start()
    {
        tiempoActivo = true;
        
    }

    public void ActualizarMagdalenas( int magdalenatotal)
    {
        textoMagdalenaMarcador.text = "Magdalenas: " + magdalenatotal;
    }

    public void ActualizarPiruletas(int piruletatotal)
    {
        textoPiruletaMarcador.text = "Piruletas: " + piruletatotal;
    }

    public void FinTiempo(int total, int total1, int total2, int magdalenatotal, int piruletatotal)
    {
        //DestroyImmediate(clone, true);
        //Instantiate(sonidoFintiempo);
        if (0 >= total1)
        {
            textoPocosObjetosRecolectados.gameObject.SetActive(true);
            Invoke("MyFunction", 3);
            //StartCoroutine(LoadYourAsyncScene());
            SceneManager.LoadScene("SalaPcipal");

        }
        else
        {
            //Nivel 1
            textofinTiempo.text= "¡Es turno de la suma!\nSuma el número de piruletas y magdalenas que marcan las cajas y pulsa la respuesta correcta: " + magdalenatotal  + " + " + piruletatotal;
            textoResultadoIncorrecto1.text = total1.ToString();
            textoResultadoIncorrecto2.text = total2.ToString();
            textoResultadoCorrecto.text = total.ToString();
            textofinTiempo.gameObject.SetActive(true);
            BotonOpcA.gameObject.SetActive(true);
            BotonOpcB.gameObject.SetActive(true);
            BotonOpcC.gameObject.SetActive(true);
        }

        if (textoCorrecto.gameObject.activeInHierarchy) {
            textofinTiempo.gameObject.SetActive(false);
            BotonOpcA.gameObject.SetActive(false);
            BotonOpcB.gameObject.SetActive(false);
            BotonOpcC.gameObject.SetActive(false);
            Invoke("MyFunction", 3);     
            SceneManager.LoadScene("Juego1_N2");

        }

        else if (textoInorrecto.gameObject.activeInHierarchy)
        {
            textofinTiempo.gameObject.SetActive(false);
            BotonOpcA.gameObject.SetActive(false);
            BotonOpcB.gameObject.SetActive(false);
            BotonOpcC.gameObject.SetActive(false);
            Invoke("MyFunction", 3);
            SceneManager.LoadScene("SalaPcipal");
        }
    }

    // Update is called once per frame
    void Update()
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
            //Nivel 1
            magdalenaInter = cajacup.contadorcake;
            ActualizarMagdalenas(magdalenaInter);
            piruletaInter = cajapiru.contadorpiruleta;
            ActualizarPiruletas(piruletaInter);
            total1 = piruletaInter + magdalenaInter - 1;
            total2 = piruletaInter + magdalenaInter + 2;
            total = piruletaInter + magdalenaInter;

        }
        else if (timer == 0) {
            FinTiempo(total, total1, total2, magdalenaInter, piruletaInter);
            textTimer.text = string.Format("{0:00}:{1:00}:{2:00}", 0, 0, 0);
        }
    }

    void MyFunction()
    {
        Debug.Log("Cambiando Escena");
    }


}
