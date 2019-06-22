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
        if (Input.GetKeyDown(KeyCode.E))
        {
            gage -= 10f;
        }

        if (timeCount % 20 == 0)
        {
            gage += 1.0f;
        }

        slider.value = gage;
    }
}
