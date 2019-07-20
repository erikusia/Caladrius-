using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BossHpFade : MonoBehaviour
{
    CanvasGroup canvasGroup;
    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }
    private void Update()
    {
        Debug.Log(Time.time);
        if (Time.time >= 15.5)
        {
            canvasGroup.alpha += Time.deltaTime;
        }
        
    }
}