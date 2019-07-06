using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gage : MonoBehaviour
{
    Slider slider;
    float gage = 100;
    private int timeCount;

    // Start is called before the first frame update
    void Start()
    {
        slider = GameObject.Find("ZSlider").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += 1;


        if (Input.GetKey(KeyCode.R) || Input.GetButton("Xbutton"))
        {
            gage -= 10f * Time.deltaTime;
        }

        if (timeCount % 20 == 0)
        {
            gage += 2.0f * Time.deltaTime;
        }

        gage = Mathf.Clamp(gage, 0, 100);
        slider.value = gage;
    }
}
