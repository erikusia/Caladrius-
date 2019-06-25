﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed = 5f;
    float MoveX;
    float MoveZ;

    Character character;
    Rigidbody rb;
    private int timeCount;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        character = GetComponent<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveX = Input.GetAxisRaw("Horizontal") * speed;
        MoveZ = Input.GetAxisRaw("Vertical") * speed;
        Vector3 direction = new Vector3(MoveX, 0, MoveZ);

        timeCount += 1;

        //移動制限
        transform.localPosition = PlayerLimit.ClampPosition(transform.localPosition);


        if (Input.GetMouseButton(0) || Input.GetButton("Abutton"))
        {
            Debug.Log("推してます");

            if (timeCount % 2f == 0)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    Transform shotPosition = transform.GetChild(i);
                    Debug.Log("出てます");
                    //shotPositionの位置方向で
                    character.Shot(shotPosition);
                }
            }

        }
    }

    void FixedUpdate()
    {
       rb.velocity = new Vector3(MoveX, 0, MoveZ);
    }




}
