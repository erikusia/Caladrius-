using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Zgage : MonoBehaviour
{
    public int ZgageBar = 100;
    public int currentGage;
    public Slider ZgageSlider;
    public Image ZgageImage;

    Animator anim;

    private int timeCount;

    bool isMax;
    bool charged;

    void Awake()
    {
        anim = GetComponent<Animator>();
        currentGage = ZgageBar;
    }



    // Update is called once per frame
    void Update()
    {
        charged = false;
    }

    public void TakeCharge()
    {
        timeCount += 1;

        charged = true;
        if (Input.GetMouseButton(0))
        { 
            if (timeCount % 5 == 0)
            {
                currentGage++;
            }
        }



        ZgageSlider.value = currentGage;

        if (currentGage <= 0 && !isMax)
        {
            Max();
        }
    }

    void Max()
    {
        isMax = true;
    }
}
