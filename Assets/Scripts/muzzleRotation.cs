using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muzzleRotation : MonoBehaviour
{
    float to = 40.0f;
    float from = -40.0f;
    float from2 = 40.0f;
    float to2 = -40.0f;
    int state;
    float time;

    public float speed = 0.5f;


    // Update is called once per frame
    void Update()
    {
        time += speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.R))
        {
            switch (state)
            {
                case 0:

                    float angle = Mathf.LerpAngle(from, to, time);
                    transform.eulerAngles = new Vector3(0, angle, 0);
                    if (angle == 40)
                    {
                        time = 0;
                        state = 1;
                    }
                    break;

                case 1:
                    float angle2 = Mathf.LerpAngle(from2, to2, time);
                    transform.eulerAngles = new Vector3(0, angle2, 0);
                    if(angle2 == -40)
                    {
                        time = 0;
                        state = 0;
                    }
                    break;
            }

        }
        else
        {
            gameObject.transform.rotation = Quaternion.Euler(0, -40, 0);
        }

    }
}
