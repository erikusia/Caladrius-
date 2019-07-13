using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gage : MonoBehaviour
{
    Slider slider;
    float gage = 100;
    private int timeCount;
    Character character;

    private Quaternion start;
    private Quaternion finish;
    private float t;

    // Start is called before the first frame update
    void Start()
    {
        slider = GameObject.Find("ZSlider").GetComponent<Slider>();
        character = GetComponent<Character>();
        start = Quaternion.Euler(0, 0, 20);
        finish = Quaternion.Euler(0, 0, -20);
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += 1;

        if (gage >= 0)
        {
            if (Input.GetKey(KeyCode.R) || Input.GetButton("Xbutton"))
            {
                gage -= 10f * Time.deltaTime;

                if (Input.GetKey(KeyCode.R) || Input.GetButton("Xbutton"))
                {

                    Transform shotposP0 = transform.GetChild(5);

                    if(t<0.01f)
                    {
                        t += 5;
                        shotposP0.rotation = Quaternion.Slerp(start, finish, t);
                    }

                    character.Beem(shotposP0);
                    Debug.Log("ビーム");
                }
            }
        }

        if (timeCount % 20 == 0)
        {
            gage += 2.0f * Time.deltaTime;
        }

        gage = Mathf.Clamp(gage, 0, 100);
        slider.value = gage;
    }
}
