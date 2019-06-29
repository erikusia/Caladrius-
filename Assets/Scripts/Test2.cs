using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartMove();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartMove()
    {
        iTween.MoveTo(gameObject, iTween.Hash("x", -3.36f,"time",5f));
        iTween.MoveAdd(gameObject, iTween.Hash("z", 10f, "time", 1f, "delay", 0.5));
    }
}
