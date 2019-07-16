using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InputKey;

public class Gage3 : MonoBehaviour
{
    Slider slider;
    float gage = 100;
    private int timeCount;
    Gage gage1;

    //static bool isCheck_Input;

    // Start is called before the first frame update
    void Start()
    {
        slider = GameObject.Find("ZSlider3").GetComponent<Slider>();

        gage1 = GetComponent<Gage>();
     
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += 1;

       

        if (Input.anyKey == false) gage1.isCheck_Input = false;
        if (Input.GetKey(KeyCode.E) || NoInput.InputB("Bbutton") && gage1.isCheck_Input == false)
        {
            Debug.Log("B");
            gage -= 10f * Time.deltaTime;
            gage = Mathf.Max(gage - 10.0f * Time.deltaTime, 0);
            gage1.isCheck_Input = true;
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
