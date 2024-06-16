using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavCanvas_Robot : MonoBehaviour
{

    private GameObject[] Robots;
    // Start is called before the first frame update
    void Start()
    {
        Robots = GameObject.FindGameObjectsWithTag("Robot");
    }

    void Update()
    {
        Robots = GameObject.FindGameObjectsWithTag("Robot");
        if (Robots[0] != null)
        {
            transform.position = Robots[0].transform.position + new Vector3(0.0f, 1.5f, 0.0f);
        }
        if (Robots[0].activeSelf == false || Robots[0]==null )
        {
            transform.gameObject.SetActive(false);
        }
        else if (Robots[0].activeSelf == true)
        {
            transform.gameObject.SetActive(true);
        }
  
    }
   

}
