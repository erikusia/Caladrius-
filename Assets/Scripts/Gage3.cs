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

    [SerializeField]
    float shotinterval;
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
                        Debug.Log("特殊弾3が出てます");
                        //shotPositionの位置方向で
                        character.Shot(shotPosition);
                    }
                    gage -= 1f;
                    yield return new WaitForSeconds(shotinterval);
                }
                else if (gage <= 0)
                {
                    Debug.Log("撃てません！");
            {
                        if (particle.isPlaying == true)
                        {
                            particle.Stop(true);
                            collider.enabled = false;
                        }

                    }

                    break;
                }
                audioSource.PlayOneShot(sound1);
            }
           

            if (timeCount % 20 == 0)
            {
                gage += 0.5f;
            }

            gage = Mathf.Clamp(gage, 0, 100);
            slider.value = gage;

            yield return null;
        }
    }
}
