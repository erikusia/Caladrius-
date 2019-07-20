using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Blink : MonoBehaviour
{
    public float interval = 1.0f;
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
        text = GetComponent<Text>();
        StartCoroutine("_Blink");
    }

    IEnumerator _Blink()
    {
        Debug.Log("Call blink");
        while (true)
        {
            //Debug.Log("BLINK image is enable:" + text.enabled);
            text.enabled = !text.enabled;
            yield return new WaitForSeconds(interval);
        }
        
    }

}

