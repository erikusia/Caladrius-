using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    [SerializeField]
    EnemyInfo[] info;

    [SerializeField]
    int infoindex=0;

    float spowsec;
    float time;
    
    // Start is called before the first frame update
    void Start()
    {
        spowsec = info[0].sec;
    }

    // Update is called once per frame
    void Update()
    {
        if (infoindex < info.Length)
        {
            time += Time.deltaTime;
            spowsec -= Time.deltaTime;
            if (time >= spowsec)
            {
                Instantiate(info[infoindex].pfbEnemy,
                    info[infoindex].pos,info[infoindex].pfbEnemy.transform.rotation);
                infoindex += 1;
                if (infoindex < info.Length)
                {
                    spowsec = info[infoindex].sec;
                }
                else if(infoindex>info.Length)
                {
                    enabled = false;
                }
            }
        }

    }

    //private void Awake()
    //{
    //    float x = transform.position.z-;
    //    var a = x - Mathf.Cos(x);
    //    transform.position = new Vector3(100, 100, 0) + new Vector3(a, 0, x);
    //}


}
