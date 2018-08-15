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
        if(Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(this.transform.position,ROTATE_SPEED * Time.deltaTime);
            if (transform.eulerAngles.z > LEFT_MAX_ANGLE && transform.eulerAngles.z < 180.0)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, LEFT_MAX_ANGLE);
            }
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(this.transform.position, ROTATE_SPEED * Time.deltaTime);
            if (transform.eulerAngles.z < RIGHT_MAX_ANGLE && transform.eulerAngles.z > 180.0)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, RIGHT_MAX_ANGLE);
            }
        }
    }
}
