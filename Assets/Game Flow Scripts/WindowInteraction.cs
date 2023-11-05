using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WindowInteraction : MonoBehaviour
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

    // Start is called before the first frame update
    void Start()
    {

    }

    [SerializeField] Transform entrySpot; //Transform where player will be dropped inside the room

    void Interact()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player"); //Get player
        player.transform.position = entrySpot.transform.position; //Move player

        //Disable the interact indicator and this script
        InteractIndicator.SetActive(false);
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameProgressionManager>().EnterWindow();
        this.enabled = false;
    }

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
    }
}
