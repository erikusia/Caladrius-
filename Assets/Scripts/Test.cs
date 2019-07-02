using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Vector3 startpos;
    public Vector3 endpos;
    public float speed;
    float distance;
    void Start()
    {
        distance = Vector3.Distance(startpos, endpos);
    }

    void Update()
    {
        float nowpos = (Time.time * speed) / distance;
        transform.position = Vector3.Lerp(startpos, endpos, nowpos);
    }
}
