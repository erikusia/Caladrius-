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
    int time;

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

    }

    IEnumerator PlayerShot()
    {
        while (true)
        {
            time += 1;
            if (Input.GetKey(KeyCode.E) || Input.GetButton("Bbutton"))
            {
                if (gage > 0)
                {

                    if (particle.isPlaying == false)
                    {
                        particle.Play(true);
                        collider.enabled = true;
                    }

                    for (int i = 0; i < 3; i++)
                    {
                        Transform shotPosition = transform.GetChild(i);
                        Debug.Log("特殊弾3が出てます");
                        //shotPositionの位置方向で
                        character.Shot(shotPosition);
                    }
                    gage -= 1;
                    yield return new WaitForSeconds(shotinterval);
                }
                else if (gage <= 0)
                {
                        if (particle.isPlaying == true)
                        {
                            particle.Stop(true);
                            collider.enabled = false;
                            
                        }
                }
                audioSource.PlayOneShot(sound1);
            }
            else if (time % 30 == 0 && (!Input.GetKey(KeyCode.E) || !Input.GetButton("Bbutton")))
            {
                Debug.Log(gage);
                gage += 2;
            }
            else
            {
                if (particle.isPlaying == true)
                {
                    particle.Stop(true);
                    collider.enabled = false;
                }

            }
            gage = Mathf.Clamp(gage, 0, 100);
            slider.value = gage;

            yield return null;
        }
    }
}
