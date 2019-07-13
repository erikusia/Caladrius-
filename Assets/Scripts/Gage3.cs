using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gage3 : MonoBehaviour
{
    Slider slider;
    float gage = 100;
    private int timeCount;
    Character character;
    [SerializeField]
    ParticleSystem particle;
    [SerializeField]
    Collider collider;
    
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<Character>();
        slider = GameObject.Find("ZSlider3").GetComponent<Slider>();
        StartCoroutine(PlayerShot());
        collider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += 1;
        //if (Input.GetKey(KeyCode.E) || Input.GetButton("Bbutton"))
        //{
        //    gage -= 10f * Time.deltaTime;
        //    gage = Mathf.Max(gage - 10.0f * Time.deltaTime, 0);
        //}

        //if (timeCount % 10 == 0)
        //{
        //    gage += 2.0f * Time.deltaTime;
        //    gage = Mathf.Min(gage + 2.0f * Time.deltaTime, 100);
        //}

        //gage = Mathf.Clamp(gage, 0, 100);
        //slider.value = gage;
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
                    //for (int i = 0; i <= 0; i++)
                    //{
                    //    Transform shotPosition = transform.GetChild(i);
                    //    Debug.Log(i);
                    //    Debug.Log("特殊弾3が出てます");
                    //    //shotPositionの位置方向で
                    //    //character.shieldShot(shotPosition);
                    //    //character.Shot(shotPosition);
                    //}

                    for (int i = 0; i < 3; i++)
                    {
                        Transform shotPosition = transform.GetChild(i);
                        Debug.Log("出てます");
                        //shotPositionの位置方向で
                        character.Shot(shotPosition);
                    }
                    gage -= 1f;
                    Debug.Log(gage);
                    yield return null;
                }
                else if (gage <= 0)
                {
                    Debug.Log("撃てません！");
                }

            }
            else /*if(Input.GetKeyUp(KeyCode.E) || Input.GetButtonUp("Bbutton"))*/
            {
                if(particle.isPlaying == true)
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
