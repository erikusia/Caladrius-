using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float scrolespeed;
    Vector3 nowpos;
    Transform nowtrans;


    // Start is called before the first frame update
    void Start()
    {
        //Startmove();
    }

    void Update()
    {
        //transformの取得
        nowtrans = transform;
        //positionの取得
        nowpos = transform.position;
        //positionのzをscrolespeed分引く
        nowpos.z -= scrolespeed;
        //positionを設定
        nowtrans.position = nowpos;

        if (nowpos.z <= -120)
        {
            this.enabled = false;
        }

        //Debug.Log(Time.time);
    }
}
