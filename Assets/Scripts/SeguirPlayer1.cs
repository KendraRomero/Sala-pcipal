using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirPlayer1 : MonoBehaviour
{
    private GameObject[] avatar;

    // Start is called before the first frame update
    void Start()
    {
        avatar = GameObject.FindGameObjectsWithTag("Player1");
    }
    private void Awake()
    {

    }
    // Update is called once per frame
    void Update()
    {
        avatar = GameObject.FindGameObjectsWithTag("Player1");
        Vector3 offset = new Vector3(0, 1f, 2); // 2 units in front of camera
        transform.position = avatar[0].transform.TransformPoint(offset);
    }
}
