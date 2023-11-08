using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootSteps : MonoBehaviour
{
    FirstPersonPlayerController controller;
    AudioSource playerAudioSource;
    [SerializeField] AudioClip[] footStepAudioClips;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<FirstPersonPlayerController>();  
        playerAudioSource = GetComponent<AudioSource>();
        currentFramesToWait = Random.Range(minFrames, maxFrames);
    }


    float frames = 0, minFrames = 30, maxFrames = 60, currentFramesToWait;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(controller.moving)
        {
            frames++;
            if(frames >= currentFramesToWait)
            {
                playerAudioSource.PlayOneShot(footStepAudioClips[Random.Range(0, footStepAudioClips.Length)]);
                frames = 0;
                currentFramesToWait = Random.Range(minFrames, maxFrames);
            }
        }
    }
}
