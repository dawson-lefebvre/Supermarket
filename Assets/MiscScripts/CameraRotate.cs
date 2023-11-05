using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    bool movingLeft;
    [SerializeField] float maxRotation = 30, rotateSpeed = 10;
    float rotationFrames = 0;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (movingLeft)
        {
            rotationFrames++;
        }
        else
        {
            rotationFrames--;
        }
        
        if (rotationFrames >= maxRotation || rotationFrames <= -maxRotation)
        {
            if(movingLeft)
            {
                movingLeft = false;
            }
            else
            {
                movingLeft = true;
            }
        }
        if (movingLeft)
        {
            transform.Rotate(Vector3.up, rotateSpeed * Time.fixedDeltaTime);
        }
        else
        {
            transform.Rotate(Vector3.up, -rotateSpeed * Time.fixedDeltaTime);
        }
    }
}
