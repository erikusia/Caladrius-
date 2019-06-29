using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBullet : MonoBehaviour
{
    private float radius;
    private float yPosition;
    public Rigidbody rbody;
    private float speed;
    Transform Nowtransform;
    Vector3 pos;
    public float bulletspeed;

    
    // Start is called before the first frame update
    void Start()
    {
        radius = 2.0f;
        yPosition = 0.5f;
        speed = 5.0f;

        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        Nowtransform = transform;
        pos = transform.position;
        pos.z -= bulletspeed;
        Nowtransform.position = pos;

        rbody.MovePosition
            (
                new Vector3(
            radius * Mathf.Sin(Time.time * speed),
            yPosition,
           
            radius * Mathf.Cos(Time.time * speed)
            )
            );
    }
}