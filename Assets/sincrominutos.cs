using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class sincrominutos : MonoBehaviour
{
    public float angMin ;
    public float angHour ;

    public float angMin_0;
    public float angHour_0 ;

    public GameObject ob_Minutos;
    public GameObject ob_Horas;


    // Start is called before the first frame update
    void Start()
    {
        angMin_0 = 0f;
        angHour_0 = 0f;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        angMin = Mathf.Round(ob_Minutos.transform.localEulerAngles.z);
        /* if (angMin < 0)
         {
             angMin += 360;
         }*/
        if (Mathf.Abs(angMin- angMin_0) >= 6f && Mathf.Abs(angMin - angMin_0) < 12f)
        {
            if((angMin - angMin_0) < 0)
            {
                angHour_0 -= 0.5f;
            }
            else 
            {
                angHour_0 += 0.5f;
            }
            angMin_0 = angMin;

        }

        if (Mathf.Abs(angMin - angMin_0) == 354f)
        {
            if ((angMin - angMin_0) > 0)
            {
                angHour_0 -= 0.5f;
            }
            else
            {
                angHour_0 += 0.5f;
            }
            angMin_0 = angMin;

        }

        /*
        if (angMin_0 > 180)
        {
            angMin_0 -= 360;
        }
        else if (angHour_0 > 180)
        {
            angHour_0 -= 360;
        }*/
 

        //ob_Minutos.transform.localEulerAngles = new Vector3(0.0f, 0.0f, angMin_0);
        ob_Horas.transform.localEulerAngles = new Vector3(0.0f, 0.0f, angHour_0);
    }
}
