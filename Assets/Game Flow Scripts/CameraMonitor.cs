using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMonitor : MonoBehaviour
{

    bool Interactable = false;
    [SerializeField] GameObject InteractIndicator;

    private void OnTriggerEnter(Collider other)
    {
        if (enabled)
        {
            if (other.tag == "InteractSphere")
            {
                Interactable = true;
                InteractIndicator.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (enabled)
        {
            if (other.tag == "InteractSphere")
            {
                Interactable = false;
                InteractIndicator.SetActive(false);
            }
        }
    }

    //Input
    [SerializeField] InputAction InteractAction;

    private void OnEnable()
    {
        InteractAction.Enable();
    }

    private void OnDisable()
    {
        InteractAction.Disable();
    }

    [SerializeField] MeshRenderer monitorMr;

    AudioSource aSource;

    private void Start()
    {
        monitorMr.material = cam1Mat;
        aSource = GetComponent<AudioSource>();
    }

    int currentCamera = 1;
    [SerializeField] Material cam1Mat, cam2Mat, darkCamMat;
    bool firstSwitch = true; //Tracks if this is the first time being switched / interacted with

    //Frame timers;
    float frames = 0, maxFrames = 5;
    bool isDarkCam = false; //Need this because apparently Unity can't determine if a material on the mesh renderer is the same as a material object

    // Update is called once per frame
    void Update()
    {
        if (Interactable)
        {
            if (InteractAction.WasPressedThisFrame())
            {
                Interact();
            }
        }

        if (currentCamera == 1)
        {
            frames++;
            if (frames >= maxFrames)
            {
                frames = 0;
                if(Random.Range(0, 5) == 4)
                {
                    //Debug.Log("Switch");
                    if (!isDarkCam)
                    {
                        monitorMr.material = darkCamMat;
                        isDarkCam = true;
                    }
                    else
                    {
                        monitorMr.material = cam1Mat;
                        isDarkCam = false;
                    }
                }
                
            }
        }
    }

    void Interact()
    {
        aSource.Play();
        //Switch materials
        if(currentCamera == 1)
        {
            currentCamera = 2;
            monitorMr.material = cam2Mat;
            if(firstSwitch)
            {
                firstSwitch = false;
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameProgressionManager>().ActivateFinalScare();
            }
        }
        else
        {
            currentCamera = 1;
            monitorMr.material = cam1Mat;
        }
    }
}
