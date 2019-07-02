using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    Slider HPSlider;
    float hp = 100;
    Bullet PlayerBullet;

    BossEnemy Boss;
    // Start is called before the first frame update
    void Start()
    {
        HPSlider = GameObject.Find("HPSlider").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerEnter(Collider col)
    {
        if (gameObject.tag == "PlayerBullet")
        {
            Debug.Log("プレイヤーの弾当たる");
            hp = hp - PlayerBullet.power;
            if (hp == 0)
            {
               
            }

        }

        HPSlider.value = hp;
    }
}
