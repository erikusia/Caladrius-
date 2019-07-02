using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gage : MonoBehaviour
{
    Slider slider;
    float gage = 100;
    private int timeCount;
    Button buttonComponent;

    // Start is called before the first frame update
    void Start()
    {
        slider = GameObject.Find("ZSlider").GetComponent<Slider>();    
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += 1;

        //buttonComponent.interactable = true;
        if (Input.GetKey(KeyCode.R) || Input.GetButton("Xbutton")) 
        {
                Debug.Log("Y");
                gage -= 10f*Time.deltaTime;
        }
        //else if(gage == 0)
        //{
        //    buttonComponent.interactable = false;
        //}
        //else if(gage >= 1 )
        //{
        //    buttonComponent.interactable = true;
        //}

        if (timeCount % 20 == 0)
        {
            gage += 2.0f*Time.deltaTime;
        }

            slider.value = gage;
    }
}
