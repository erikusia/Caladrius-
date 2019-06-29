﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    Character character;
    public int rotspeed;
    int state;
    public float TimeCount = 0;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        character = GetComponent<Character>();
        character.Move(transform.forward * -1);
        state = 0;
        

        while (true)
        {
            TimeCount += 1;

            yield return new WaitForSeconds(0.05f);
            for (int i = 0; i < transform.childCount; i++)
            {

                switch (state)
                {
                    case 0:
                        //子要素全てから弾が出る
                        Debug.Log("通常");
                        Transform shotPosition0 = transform.GetChild(i);

                        //撃つ処理
                        character.Shot0(shotPosition0);
                        if(TimeCount >= 5)
                        {
                            state = 1;
                        }
                        break;
                    case 1:
                        Debug.Log("拡散");
                        //gameObject.transform.GetChild(3);
                        //gameObject.transform.GetChild(4);

                        //playerに向かって撃つ shotposP
                        Transform shotposP0 = transform.GetChild(0);
                        Transform shotposP1 = transform.GetChild(1);
                        Transform shotposP2 = transform.GetChild(2);

                        //左右に拡散 shotPosition
                        Transform shotPosition1 = transform.GetChild(3);
                        Transform shotPosition2 = transform.GetChild(4);

                        character.Shot0(shotposP0);
                        character.Shot0(shotposP1);
                        character.Shot0(shotposP2);
                        character.Shot1(shotPosition1);
                        character.Shot1(shotPosition2);
                        if (TimeCount >= 10)
                        {
                            state = 2;
                        }
                        break;
                    case 2:
                        Debug.Log("ケース２");
                        //playerに向かって撃つ shotposP
                        Transform shotposP3 = transform.GetChild(0);
                        Transform shotposP4 = transform.GetChild(1);
                        Transform shotposP5 = transform.GetChild(2);

                        //円状に拡散 shotPosition
                        Transform shotPosition3 = transform.GetChild(5);
                        Transform shotPosition4 = transform.GetChild(6);
                        character.Shot0(shotposP3);
                        character.Shot0(shotposP4);
                        character.Shot0(shotposP5);
                        character.Shot2(shotPosition3);
                        character.Shot2(shotPosition4);
                        if (TimeCount>=20)
                        {
                            Debug.Log("3");
                            state = 3;
                        }
                        break;
                    case 3:
                        if(TimeCount>=30)
                        {
                            state = 1;
                            TimeCount = 0;
                        }
                        break;
                }

                //Transform shotPosition = transform.GetChild(i);

                //shotPositionの位置方向で撃つ
                //character.Shot0(shotPosition);
            }

            yield return new WaitForSeconds(character.shotinterval);
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(Vector3.forward * rotspeed);
    }
}
