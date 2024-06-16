using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class NavMeshController1 : MonoBehaviour
{
    NavMeshAgent agent = null;
    Animator anim;
    private GameObject[] avatar;


    void Start()
    {
       agent = GetComponent<NavMeshAgent>();
       anim = GetComponent<Animator>();
       avatar = GameObject.FindGameObjectsWithTag("Player1");

    }

    private void Awake()
    {
        
    }

    void Update()
    {
     
        avatar = GameObject.FindGameObjectsWithTag("Player1");
        if (avatar[0] != null)
        {
            agent.destination = avatar[0].transform.position + new Vector3(1.5f, 0.0f, 1.5f);
        }
        
        UpdateAnimation();
      
    }

    void UpdateAnimation()
    {
        float speed;
        speed = agent.velocity.magnitude;
        speed = Mathf.Clamp01(speed);
        anim.SetFloat("Speed", speed, 0.1f, Time.deltaTime);
    }
}
