using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gage2 : MonoBehaviour
{
    Slider slider;
    float gage = 100;
    private int timeCount;

    // Start is called before the first frame update
    void Start()
    {
        slider = GameObject.Find("ZSlider2").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
        timeCount += 1;
        if (Input.GetKey(KeyCode.F)|| Input.GetButton("Ybutton"))
        {
            gage -= 10f * Time.deltaTime;

            gage = Mathf.Max(gage - 10f * timeCount.deltaTime, 0);
        }

        if (timeCount % 30 == 0)
        {
            gage += 2.0f * Time.deltaTime;

            gage = Mathf.Min(gage + 2.0f * Time.detaTime, 100);
        }
        
        Debug.Log(gage);

        gage = Mathf.Clamp(gage, 0, 100);
        slider.value = gage;
    }
}
