using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleShooter : MonoBehaviour
{
    private const float ROTATE_SPEED = 90f;
    private const float LEFT_MAX_ANGLE = 85f;
    private const float RIGHT_MAX_ANGLE = 275f;

    private void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.back * ROTATE_SPEED * Time.deltaTime*-1);
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back * ROTATE_SPEED * Time.deltaTime);

        }
    }
}
