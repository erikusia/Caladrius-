using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iTweenPathMove : MonoBehaviour
{
    public float MoveTime=100;
    public string PathName = "New Path 1";
    // Start is called before the first frame update
    void Start()
    {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath(PathName),
            "time", MoveTime, "easeType", iTween.EaseType.linear, "orienttopath", true));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
