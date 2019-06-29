﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBullets : MonoBehaviour
{
    Character character;
    float TimeCount = 0;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        character = GetComponent<Character>();
        //character.Move(transform.forward * -1);
;

        while (true)
        {
            yield return new WaitForSeconds(2.5f);
            for (int i = 0; i < transform.childCount; i++)
            {
                    Debug.Log("拡散しています");

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
