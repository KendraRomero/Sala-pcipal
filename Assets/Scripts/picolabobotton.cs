using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class picolabobotton : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject[] Robots;
    public GameObject picolaboButtonR;
    public Button picolaboButton;

    void Start()
    {
        Robots = GameObject.FindGameObjectsWithTag("Robot");
        Button btn = picolaboButton.GetComponent<Button>();
        btn.onClick.AddListener(OnclickEnable);
    }

    public void OnclickEnable()
    {
        foreach (GameObject obj in Robots)
        {
            obj.SetActive(true);
        }
    }
}
