using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reinstance : MonoBehaviour
{
    public static Reinstance instance;

    void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}