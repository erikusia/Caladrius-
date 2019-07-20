using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InputKey;

public class Gage : MonoBehaviour
{
    Slider slider;
    float gage = 100;
    private int timeCount;
    Character character;

    private Quaternion start;
    private Quaternion finish;
    private float t;

    public AudioClip sound1;
    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        slider = GameObject.Find("ZSlider").GetComponent<Slider>();
        character = GetComponent<Character>();
        start = Quaternion.Euler(0, 0, 20);
        finish = Quaternion.Euler(0, 0, -20);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += 1;

        if (gage >= 0)
        {
            if (Input.GetKey(KeyCode.R) || MyInput.MyInputButton("Xbutton"))
            {
                gage -= 1f;
                gage = Mathf.Max(gage - 10.0f * Time.deltaTime, 0);

                if (Input.GetKey(KeyCode.R) || MyInput.MyInputButton("Xbutton"))
                {

                    Transform shotposP0 = transform.GetChild(5);

                    if(t<0.01f)
                    {
                        t += 5;
                        shotposP0.rotation = Quaternion.Slerp(start, finish, t);
                    }

                    character.Beem(shotposP0);
                    audioSource.PlayOneShot(sound1);
                    Debug.Log("ビーム");
                }
            }
        }

        if (timeCount % 10 == 0)
        {
            gage += 0.5f * Time.deltaTime;
        }

        gage = Mathf.Clamp(gage, 0, 100);
        slider.value = gage;
    }
}