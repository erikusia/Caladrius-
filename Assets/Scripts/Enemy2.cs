﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    Character character;
    public Vector3 vector3;
    float dist;
    EnemyManager manager;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        character = GetComponent<Character>();
        manager = GetComponent<EnemyManager>();
        character.Move(Vector3.forward * -1);
       
        while (true)
        {
            yield return new WaitForSeconds(0.05f);
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform shotPosition = transform.GetChild(i);

                //shotPositionの位置方向で撃つ
                character.Shot0(shotPosition);
            }

            yield return new WaitForSeconds(character.shotinterval);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
