using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    Light lightComponent;
    AudioSource aSource;
    // Start is called before the first frame update
    void Start()
    {
        lightComponent = GetComponent<Light>();
        aSource = GetComponent<AudioSource>();
    }

    float frames = 0, maxFrames = 2;
    // Update is called once per frame
    void FixedUpdate()
    {
        frames++;
        if(frames >= maxFrames)
        {
            frames = 0;
            if(Random.Range(0, 4) == 3)
            {
                if (lightComponent.enabled)
                {
                    lightComponent.enabled = false;
                    aSource.enabled = false;
                }
                else
                {
                    lightComponent.enabled = true;
                    aSource.enabled = true;
                }
            }
        }
    }
}
