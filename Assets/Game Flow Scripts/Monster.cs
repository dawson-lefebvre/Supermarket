using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float speed = 10f;
    [SerializeField] GameObject player;
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(player.transform.position);
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
        transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.tag == "Player")
        {
            EditorApplication.ExitPlaymode();
        }
    }
}
