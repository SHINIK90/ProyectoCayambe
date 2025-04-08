using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Play_Video : MonoBehaviour
{
    public VideoPlayer vid;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (vid.isPlaying)
            {
                vid.Pause();
            }
            else
            {
                vid.Play();
            }
        }
    }
}
