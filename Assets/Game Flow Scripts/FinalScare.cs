using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScare : MonoBehaviour
{
    public float secondsToLook = 3;
    [SerializeField] GameObject monster;

    IEnumerator coroutine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SightSphere")
        {
            coroutine = WaitToScare();
            StartCoroutine(coroutine);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "SightSphere")
        {
            StopCoroutine(coroutine);
        }
    }

    IEnumerator WaitToScare()
    {
        yield return new WaitForSeconds(secondsToLook);
        monster.SetActive(true);
    }
}
