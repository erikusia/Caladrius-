using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    public Vector3 startpos;
    public Vector3 endpos;
    public float speed;
    float time;
    float distance;
    void Start()
    {
        distance = Vector3.Distance(startpos, endpos);
    }

    void Update()
    {
        time += Time.deltaTime;
        Debug.Log(time);
        float nowpos = (time * speed) / distance;
        transform.position = Vector3.Lerp(startpos, endpos, nowpos);
    }
}
