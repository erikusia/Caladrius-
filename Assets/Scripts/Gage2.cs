using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Gage2 : MonoBehaviour
{
    Slider slider;
    float gage = 100;
    private int timeCount;
    Character character;

    [SerializeField]
    float shotinterval;

    public AudioClip sound1;
    AudioSource audioSource;
    int time;


    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<Character>();
        slider = GameObject.Find("ZSlider2").GetComponent<Slider>();
        StartCoroutine(PlayerShot());
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += 1;
    }

    IEnumerator PlayerShot()
    {
        while (true)
        {
            time += 1;
            if (Input.GetKey(KeyCode.F) || Input.GetButton("Ybutton"))
            {
                if (gage > 0)
                {
                    for (int i = 3; i <= 4; i++)
                    {
                        Transform shotPosition = transform.GetChild(i);
                        Debug.Log(i);
                        Debug.Log("特殊弾2が出てます");
                        //shotPositionの位置方向で
                        character.specialShot(shotPosition);
                    }
                    gage -= 1f;
                    yield return new WaitForSeconds(shotinterval);
                }
                //else if (gage <= 0)
                //{
                    
                //}
                audioSource.PlayOneShot(sound1);

            }

            else if (time%60==0&& (!Input.GetKey(KeyCode.F) || !Input.GetButton("Ybutton")))
            {
                gage += 0.5f;
            }

            Debug.Log(time % 60);
            gage = Mathf.Clamp(gage, 0, 100);
            slider.value = gage;

            yield return null;
        }
    }
}
