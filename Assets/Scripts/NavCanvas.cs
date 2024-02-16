using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavCanvas : MonoBehaviour
{
    public Transform PosSeguir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PosSeguir != null)
        {
            transform.position = PosSeguir.position + new Vector3(1.5f, 1f, 0.0f);
        }
    }
}
