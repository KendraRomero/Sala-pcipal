using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class video_intru : MonoBehaviour
{
    // Start is called before the first frame update
    public VideoPlayer video;

    void Start()
    {
        video = GetComponent<VideoPlayer>();
       
    }
    private void Awake()
    {
        // video.Play();

    }

    // Update is called once per frame
    void Update()
    {
           
    }
}
