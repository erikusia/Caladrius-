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
    float ntime;
    
    // Start is called before the first frame update
    void Start()
    {
        spowsec = info[0].sec;
        ntime=info[0].sec;
    }

    // Update is called once per frame
    void Update()
    {
        if (infoindex < info.Length)
        {
            time += Time.deltaTime;
            spowsec -= Time.deltaTime;
            if (time >= ntime)
            {
                Instantiate(info[infoindex].pfbEnemy);
                infoindex += 1;
                if (infoindex < info.Length)
                {
                    ntime = info[infoindex].sec;
                }
                else
                {
                    this.enabled = false;
                }
            }
        }
    }

}
