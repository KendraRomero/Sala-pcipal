using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlDelJuego3 : MonoBehaviour
{
    [SerializeField] private TMP_Text horadigital;
    [SerializeField] public TextMeshProUGUI[] Horas = new TextMeshProUGUI[13];

    int horas;
    int minutoss;
    public GameObject pointerMinutes;
    public GameObject pointerHours;
    readonly int[] angulosPosibles = { 0, 30, 60, 90, 120, 150, 180, 210, 240, 270, 300, 330, 360 };
    public GameObject boton;
    public GameObject y_2;
    public GameObject x_2;
    public GameObject score_final;
    int countcorrecto;
    int countfallos;
    float timerScore_final;
    float timerScore_final1;
    int flag;
    bool finjuego;
    int minIndexH;
    int minIndexM;
    int flagColor;
    int niveles;
    public string colordefault;
    public string color_h;
    public string color_m;
    public TextMeshProUGUI nivel;
    public TextMeshProUGUI aciertos;
    public TextMeshProUGUI fallos;
    public TextMeshProUGUI aciertos_finales;
    public TextMeshProUGUI fallos_finales;
    bool noprimerN1;
    bool noprimerN2;
    bool noprimerN3;
    int correcto1;
    int correcto2;
    int correcto3;

    float angulosposH;
    float angulosposM;


    // Start is called before the first frame update
    void Start()
    {
        flag=0;
        timerScore_final = 0.0f;
        timerScore_final1 = 0.0f;
        Nivel1();
        countcorrecto = 0;
        countfallos = 0;
        noprimerN1 = false;
        noprimerN2 = false;
        noprimerN3 = false;
        finjuego = false;
        minIndexH = 0;
        minIndexM = 0;
        flagColor = 0;
        colordefault = "white";
        color_h = "#EC89D6";
        color_m = "#3DE2C3";
        Horas[0].text = "<color=" + color_h + ">" + 12 + "</color>";
        correcto1 = 0;
        correcto2 = 0;
        correcto3 = 0;
        niveles = 0;
        angulosposH = 0;
        angulosposM = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float pos0m = pointerMinutes.transform.localEulerAngles.z;
        float pos0h = pointerHours.transform.localEulerAngles.z;
        float pos1m;
        float pos1h;

        StartCoroutine(Delaysec());
        pos1m = pointerMinutes.transform.localEulerAngles.z;
        pos1h = pointerHours.transform.localEulerAngles.z;

        if (pos1m == pos0m)
        {
            ActualizarPosicionMinutos();
        }

        if ( pos1h == pos0h)
        {
            ActualizarPosicionHoras();
        }
        
        if (boton.activeSelf == false)
        {
            if (flag == 0)
            {
              Comprobacion();
            }

            timerScore_final1 += Time.deltaTime;
            if (timerScore_final1 > 1.3f)
            {
                flag = 0;
                x_2.SetActive(false);
                y_2.SetActive(false);
                CambioNivel(niveles);
                timerScore_final1 = 0;
            }
            
        }

    }


    void Comprobacion()
    {
        
        float minutofinal = Mathf.Round(pointerMinutes.transform.localEulerAngles.z % 360);
        float horafinal = Mathf.Round(pointerHours.transform.localEulerAngles.z % 360);

        if ((horas*30)%360 == horafinal && (minutoss*6)%360 == minutofinal)
        {
            y_2.SetActive(true);
            FindObjectOfType<AudioManager>().Play("win");
            countcorrecto++;
        }
        else
        {
            x_2.SetActive(true);
            FindObjectOfType<AudioManager>().Play("error");
            countfallos++;
        }
        flag = 1;
        
    }

    public void GetNivel(int niveles_eleccion)
    {
        niveles = niveles_eleccion;
    }
    //NIVELES
   public void CambioNivel(int niveles_)
    {
        
        boton.SetActive(true);
        switch (niveles_)
        {
            case 1:
                correcto1 = countcorrecto;
                Nivel1();
                nivel.text = "Nivel: 1";
                if (correcto1==5)
                {
                    niveles++;
                }
                break;
            case 2:
                correcto2 = countcorrecto-correcto1;
                Nivel2();
                nivel.text = "Nivel: 2";
                if (correcto2 == 5)
                {
                    
                    niveles++;
                }
                break;
            case 3:
                correcto3 = countcorrecto -correcto1-correcto2;
                Nivel3();
                nivel.text = "Nivel: 3";
                break;
        }
               
        aciertos.text = "Aciertos: " + countcorrecto;
        fallos.text = "Fallos: " + countfallos;

        if (  correcto3 > 4)
        {
            aciertos_finales.text = "Aciertos: " + countcorrecto;
            fallos_finales.text = "Fallos: " + countfallos;
            finjuego = true;
            score_final.SetActive(true);
            timerScore_final += Time.deltaTime;
            score_final.SetActive(true);
            if (timerScore_final > 1f)
            {
                SceneManager.LoadScene("SalaPcipal");
            }
               
        }
    }

    void Nivel1()
    {
        int minuto_anterior = minutoss;
        int hora_anterior = horas;
        horas = Random.Range(1, 13);
        minutoss= Random.Range(0, 2)* 30;
        if (noprimerN1==true && minuto_anterior == minutoss && hora_anterior ==horas)
        {
            horas = Random.Range(1, 13);
            minutoss = Random.Range(0, 2) * 30;
        }
        horadigital.text = string.Format("{0:00}:{1:00}", horas, minutoss);
        noprimerN1 = true;
    }
    
    void Nivel2()
    {
        int minuto_anterior = minutoss;
        int hora_anterior = horas;
        horas = Random.Range(1, 13);
        minutoss = Random.Range(0, 4) * 15;
        if (noprimerN2 == true && minuto_anterior == minutoss && hora_anterior == horas)
        {
            horas = Random.Range(1, 13);
            minutoss = Random.Range(0, 4) * 15;
        }
        horadigital.text = string.Format("{0:00}:{1:00}", horas, minutoss);
        noprimerN2 = true;
    }

    void Nivel3()
    {
        int minuto_anterior = minutoss;
        int hora_anterior = horas;
        horas = Random.Range(1, 13);
        minutoss = Random.Range(0, 12) * 5;
        if (noprimerN3 == true && minuto_anterior == minutoss && hora_anterior == horas)
        {
            horas = Random.Range(1, 13);
            minutoss = Random.Range(0, 12) * 5;
        }
        horadigital.text = string.Format("{0:00}:{1:00}", horas, minutoss);
        noprimerN3 = true;
    }

    //ACTUALIZAR POSICIONES MANILLAS
    void ActualizarPosicionMinutos()
    {
 
        float alpha = pointerMinutes.transform.localEulerAngles.z % 360;
        float[] beta = new float[13];

        for (int i=0; i<13;i++)
        {
            beta[i] = Mathf.Abs(angulosPosibles[i] - alpha);
        }
        float min = beta[0];
        minIndexM = 0;

        for (int i = 1; i < 13; ++i)
        {
            if (beta[i] < min)
            {
                min = beta[i];
                minIndexM = i;
            }
        }

        pointerMinutes.transform.localEulerAngles = new Vector3(0.0f, 0.0f, angulosPosibles[minIndexM]);
        if (angulosposM != angulosPosibles[minIndexM])
        {
            flagColor = 1;
        }
        angulosposM = angulosPosibles[minIndexM];
        ChangeColor(minIndexH, minIndexM, colordefault);
    }
    
    void ActualizarPosicionHoras()
    {

        float alpha = pointerHours.transform.localEulerAngles.z % 360;
        float[] beta = new float[13];

        for (int i = 0; i < 13; i++)
        {
            beta[i] = Mathf.Abs(angulosPosibles[i] - alpha);
        }


        float min = beta[0];
        minIndexH = 0;

        for (int i = 1; i < 13; ++i)
        {
            if (beta[i] < min)
            {
                min = beta[i];
                minIndexH = i;
            }
        }
        pointerHours.transform.localEulerAngles = new Vector3(0.0f, 0.0f, angulosPosibles[minIndexH]);
        if (angulosposH != angulosPosibles[minIndexH])
        {
            flagColor = 2;
        }
        angulosposH = angulosPosibles[minIndexH];
        ChangeColor(minIndexH, minIndexM, colordefault);
    }

    void ChangeColor(int minIndexH, int minIndexM , string colordefault)
    {

        
        for (int i=0; i< 13; i++)
        {

            if (i != 0 && i != 12)
            {
                Horas[i].text = "<color=" + colordefault + ">" + i + "</color>";
            }

            if (i != minIndexM && i != minIndexH)
            {
                if ( (i == 0 && minIndexM!=12 && minIndexH !=12) || (i == 12 && minIndexM != 0 && minIndexH != 0) )
                {
                    Horas[i].text = "<color=" + colordefault + ">" + (i == 0 ? 12 : i) + "</color>";
                }     
            }

            if ( (i == minIndexM || i == minIndexH) && (minIndexH != minIndexM))
            {
                if (i == minIndexH)
                {
                    Horas[i].text = "<color=" + color_h + ">" + (i == 0 ? 12 : i) + "</color>";
                  
                }
                if (i == minIndexM)
                {        
                    Horas[i].text = "<color=" + color_m + ">" + (i == 0 ? 12 : i) + "</color>";
                   // flagColor = 2; //blue   

                }
                
            }
            
            if (i == minIndexM && i == minIndexH && flagColor==1)
            {
                Horas[i].text = "<color=" + color_m + ">" + (i == 0 ? 12 : i) + "</color>";

            }
            else if (i == minIndexM && i == minIndexH && flagColor == 2)
            {
                Horas[i].text = "<color=" + color_h + ">" + (i == 0 ? 12 : i) + "</color>";
            }
        }
    }


    private IEnumerator Delaysec()
    {
        yield return new WaitForSeconds(7);
    }
}
