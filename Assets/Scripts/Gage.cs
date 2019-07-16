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
    float time;

    public AudioClip sound1;
    AudioSource audioSource;

    public bool isCheck_Input;

    // Start is called before the first frame update
    void Start()
    {
        slider = GameObject.Find("ZSlider").GetComponent<Slider>();
        character = GetComponent<Character>();
        start = Quaternion.Euler(0, 0, 20);
        finish = Quaternion.Euler(0, 0, -20);
        audioSource = GetComponent<AudioSource>();

        StartCoroutine(GageIE());
    }

    // Update is called once per frame
    IEnumerator GageIE()
    {
        Debug.Log("a");



        while (true)
        {
 
            if (gage != 0.0f )
            {

                if (Input.anyKey)
                {
                    isCheck_Input = false;

                    if (Input.GetKey(KeyCode.R) || Input.GetButton("Xbutton") && isCheck_Input == false)
                    {
                        gage -= 0.03f;
                        gage = Mathf.Max(gage - 10.0f * Time.deltaTime, 0);

                        //if (Input.GetKey(KeyCode.R) || Input.GetButton("Xbutton") && isCheck_Input == false)
                        //{

                        Transform shotposP0 = transform.GetChild(5);

                        if (t < 0.01f)
                        {
                            t += 5;
                            shotposP0.rotation = Quaternion.Slerp(start, finish, t);
                        }

                        character.Beem(shotposP0);
                        audioSource.PlayOneShot(sound1);
                        Debug.Log("ビーム");
                        //}

                        isCheck_Input = true;
                    }
                }
                
            }
            gage = Mathf.Clamp(gage, 0, 100);
            slider.value = gage;


            time += 1.0f * Time.deltaTime;

            if(time >= 10)
            {
                gage += 5.0f;
                time = 0;
                gage = Mathf.Min(gage + 2.0f * Time.deltaTime, 100);
            }

            Debug.Log(gage);
            yield return null;
        }

    }
}
