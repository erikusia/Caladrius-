using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // 移動スピード
    public float speed = 5;

    void Update()
    {
        // 右・左
        float x = Input.GetAxisRaw("Horizontal");

        // 上・下
        float z = Input.GetAxisRaw("Horizontal");

        // 移動する向きを求める
        Vector2 direction = new Vector3(x,0, z).normalized;

        // 移動する向きとスピードを代入する
        GetComponent<Rigidbody>().velocity = direction * speed;
    }
}
