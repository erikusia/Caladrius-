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
    Character character;
    ParticleSystem particle;
    Collider collider;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<Character>();
        slider = GameObject.Find("ZSlider3").GetComponent<Slider>();
        
        particle = GameObject.Find("PlayerShield 1").GetComponent<ParticleSystem>();
        collider = GameObject.Find("PlayerShield 1").GetComponent<Collider>();
        collider.enabled = false;

        StartCoroutine(PlayerShot());
        //Debug.Log(particle);
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator PlayerShot()
    {
        while (true)
        {
            
            if (Input.GetKey(KeyCode.E) || Input.GetButton("Bbutton"))
            {
               if( particle.isPlaying  == false)
                {
                    particle.Play(true);
                    collider.enabled = true;
                }
                if (gage > 0)
                {

                    for (int i = 0; i < 3; i++)
                    {
                        Transform shotPosition = transform.GetChild(i);
                        Debug.Log("出てます");
                        //shotPositionの位置方向で
                        character.Shot(shotPosition);
                    }
                    gage -= 1f;
                    //Debug.Log(gage);
                    yield return null;
                }
                else if (gage <= 0)
                {
                    Debug.Log("撃てません！");
                }

            }
            else 
            {
                if (particle.isPlaying)
                {
                    particle.Stop(true);
                    collider.enabled = false;
                }

            }

            if (timeCount % 10 == 0)
            {
                gage += 2.0f * Time.deltaTime;
            }

            gage = Mathf.Clamp(gage, 0, 100);
            slider.value = gage;

            yield return null;
        }
    }
}
