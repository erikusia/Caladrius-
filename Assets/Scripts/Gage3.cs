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
    [SerializeField]
    ParticleSystem particle;
    [SerializeField]
    Collider collider;
    Gage gage1;

    static bool isCheck_Input;

    public AudioClip sound1;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<Character>();
        slider = GameObject.Find("ZSlider3").GetComponent<Slider>();
        StartCoroutine(PlayerShot());
        collider.enabled = false;

        gage1 = GetComponent<Gage>();
        audioSource = GetComponent<AudioSource>();
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

        //if (Input.anyKey == false) gage1.isCheck_Input = false;
        //if (Input.GetKey(KeyCode.E) || NoInput.InputB("Bbutton") && gage1.isCheck_Input == false)
        //{
        //    Debug.Log("B");
        //    gage -= 10f * Time.deltaTime;
        //    gage = Mathf.Max(gage - 10.0f * Time.deltaTime, 0);
        //    gage1.isCheck_Input = true;
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
                audioSource.PlayOneShot(sound1);
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
