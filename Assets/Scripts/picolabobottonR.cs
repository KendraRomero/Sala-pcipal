using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class picolabobottonR : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject[] Robots;
    public GameObject picolaboButton;
    public Button picolaboButtonR;


    void Start()
    {
        Robots = GameObject.FindGameObjectsWithTag("Robot");
        Button btn = picolaboButtonR.GetComponent<Button>();
        btn.onClick.AddListener(OnclickDisable);
    }

    public void OnclickDisable()
    {
        foreach (GameObject obj in Robots)
        {
            obj.SetActive(false);
        }
    }

}
