using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DoorWithSparks : MonoBehaviour
{

    //Door animator references
    [SerializeField] Animator rightDoor, leftDoor;

    //Spark particle system
    [SerializeField] GameObject Sparks;

    //Spark location bounds
    [SerializeField] Collider sparksArea;

    bool Interactable = false;

    //Interact UI
    [SerializeField] GameObject InteractIndicator;

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
        rightDoor.enabled = false;
        leftDoor.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(enabled)
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

    private void Update()
    {
        if (Interactable)
        {
            if (InteractAction.WasPressedThisFrame())
            {
                Interact();
            }
        }
    }

    public void Interact()
    {
        //Start animations
        rightDoor.enabled = true;
        leftDoor.enabled = true;

        //Disable interactablility
        Interactable = false;
        InteractIndicator.SetActive(false);

        //Start spark spawn Coroutine
        StartCoroutine(SpawnSparks());
        StartCoroutine(FinishDoorSequence());
    }

    //Number of sparks to spawn
    public int numeberOfSparks = 3;
    IEnumerator SpawnSparks()
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < numeberOfSparks; i++)
        {
            GameObject s = Instantiate(Sparks);
            s.transform.position = PickRandomSpot(sparksArea.bounds);
        }
    }

    IEnumerator FinishDoorSequence()
    {
        yield return new WaitForSeconds(2);
        rightDoor.enabled = false;
        leftDoor.enabled = false;
        Interactable = false;
        InteractIndicator.SetActive(false);
        this.enabled = false;
    }

    Vector3 PickRandomSpot(Bounds bounds)
    {
        return new Vector3(
        Random.Range(bounds.min.x, bounds.max.x),
        Random.Range(bounds.min.y, bounds.max.y),
        Random.Range(bounds.min.z, bounds.max.z)
    );
    }
}
