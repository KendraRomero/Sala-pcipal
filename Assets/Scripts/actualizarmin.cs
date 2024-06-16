using UnityEngine;
using System.Collections;

public class actualizarmin : MonoBehaviour
{
    public bool noColision;

    void Start()
    {
        noColision = false;
    }

    void OnCollisionExit(UnityEngine.Collision other2)
    {
        if (other2.gameObject.tag == "Player")
        {
            noColision = true;
        }
    }

    void OnCollisionEnter(UnityEngine.Collision other1)
    {

        if (other1.gameObject.tag == "Player")
        {
            noColision = false;
        }
    }
}
