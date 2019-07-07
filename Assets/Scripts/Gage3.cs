using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gage3 : MonoBehaviour
{
    Slider slider;
    float gage = 100;
    private int timeCount;

    // Start is called before the first frame update
    void Start()
    {
        slider = GameObject.Find("ZSlider3").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += 1;
        if (Input.GetKey(KeyCode.E) || Input.GetButton("Bbutton"))
        {
            gage -= 10f * Time.deltaTime;
            gage = Mathf.Max(gage - 10.0f * Time.deltaTime, 0);
        }

        if (timeCount % 10 == 0)
        {
            gage += 2.0f * Time.deltaTime;
            gage = Mathf.Min(gage + 2.0f * Time.deltaTime, 100);
        }

        gage = Mathf.Clamp(gage, 0, 100);
        slider.value = gage;
    }
}
