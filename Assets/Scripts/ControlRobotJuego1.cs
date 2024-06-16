using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlRobotJuego1 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject picolaboR1;
    private GameObject[] Robots;
    void Start()
    {
        Robots = GameObject.FindGameObjectsWithTag("Robot1");
    }

    // Update is called once per frame
    void Update()
    {
        Robots = GameObject.FindGameObjectsWithTag("Robot1");
        if (picolaboR1.activeSelf == true)
        {
            Robots[0].SetActive(true);
        }
        else if (picolaboR1.activeSelf == false)
        {
            Robots[0].SetActive(false);

        }
    }
}
