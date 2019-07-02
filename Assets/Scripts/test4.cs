using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test4 : MonoBehaviour
{
    public Vector3 startpos;
    public Vector3 endpos;
    public Vector3 target;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        target = transform.position + transform.forward;
        transform.position = Vector3.Lerp
            (transform.position, target, Time.deltaTime);
    }
}
