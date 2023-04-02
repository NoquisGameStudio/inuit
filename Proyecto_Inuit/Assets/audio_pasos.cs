using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio_pasos : MonoBehaviour
{
    // Start is called before the first frame update

    public movement mov;
    public AudioSource audio;
    void Start()
    {
        audio.volume = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(mov.mov.x!= mov.mov.y  )
        {
            audio.volume = 1;
        }
        else
        {
            audio.volume = 0;
        }
    }
}
