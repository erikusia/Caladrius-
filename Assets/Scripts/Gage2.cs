using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gage2 : MonoBehaviour
{
    //Slider slider;
    //float gage = 100;
    //private int timeCount;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    slider = GameObject.Find("ZSlider2").GetComponent<Slider>();
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //    timeCount += 1;
    //    if (Input.GetKey(KeyCode.F)|| Input.GetButton("Ybutton"))
    //    {
    //        gage -= 10f * Time.deltaTime;

    //        gage = Mathf.Max(gage - 10.0f * Time.deltaTime, 0);
    //    }

    //    if (timeCount % 10 == 0)
    //    {
    //        gage += 2.0f * Time.deltaTime;

    //        gage = Mathf.Min(gage + 2.0f * Time.deltaTime, 100);
    //    }

    //    //Debug.Log(gage);

    //    gage = Mathf.Clamp(gage, 0, 100);
    //    slider.value = gage;
    //}

    Slider slider;
    float gage = 100;
    private int timeCount;
    Character character;

    [SerializeField]
    float shotinterval;


    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<Character>();
        slider = GameObject.Find("ZSlider2").GetComponent<Slider>();
        StartCoroutine(PlayerShot());
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
                    gage -= 100f;
                    Debug.Log(gage);
                    yield return new WaitForSeconds(shotinterval);
                }
                else if (gage <= 0)
                {
                    Debug.Log("撃てません！");
                }

            }

            if (timeCount % 20 == 0)
            {
                gage += 2.0f * Time.deltaTime;
            }

            gage = Mathf.Clamp(gage, 0, 100);
            slider.value = gage;

            yield return null;
        }
    }
}
