using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    Light lightComponent;
    // Start is called before the first frame update
    void Start()
    {
        lightComponent = GetComponent<Light>();
    }

    float frames = 0, maxFrames = 2;
    // Update is called once per frame
    void Update()
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
                }
                else
                {
                    lightComponent.enabled = true;
                }
            }
        }
    }
}
