using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleShooter : MonoBehaviour
{
    private const float ROTATE_SPEED = 90f;

    private void Update()
    {
        Vector3 currentRotation = transform.localRotation.eulerAngles;
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.back * ROTATE_SPEED * Time.deltaTime * -1);
            Debug.Log(currentRotation.z);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back * ROTATE_SPEED * Time.deltaTime);
            Debug.Log(currentRotation.z);
        }


        if (currentRotation.z > 65.0f && currentRotation.z < 180.0f)
        {
            currentRotation.z = 65.0f;
            transform.localRotation = Quaternion.Euler(currentRotation);
        }

        else if(currentRotation.z<295.0 && currentRotation.z >180.0f)
        {
            currentRotation.z = 295.0f;
            transform.localRotation = Quaternion.Euler(currentRotation);
        }
    }
}
