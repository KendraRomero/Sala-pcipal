using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class NavMeshController : MonoBehaviour
{
    NavMeshAgent agent = null;
    Animator anim;
    private GameObject[] avatar;


    void Start()
    {
       agent = GetComponent<NavMeshAgent>();
       anim = GetComponent<Animator>();
       avatar = GameObject.FindGameObjectsWithTag("Player");

    }

    private void Awake()
    {
        
    }

    void Update()
    {
     
        avatar = GameObject.FindGameObjectsWithTag("Player");
        if (avatar[0] != null)
        {
            agent.destination = avatar[0].transform.position + new Vector3(1.5f, 0.0f, 1.5f);
        }
        else if (avatar[0] == null)
        {
            agent.destination =  new Vector3(10.48f, 1.21f, -113.21f);
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
