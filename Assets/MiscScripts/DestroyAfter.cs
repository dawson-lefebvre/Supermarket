using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    public float seconds = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RemoveAfter());
    }

    IEnumerator RemoveAfter()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
