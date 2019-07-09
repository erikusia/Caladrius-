﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float BulletSpeed = 5;

    public int power = 1;

    PlayerShield playerShield;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward* BulletSpeed;
    }


    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<Renderer>().isVisible)
        {
            //Debug.Log("画面外です");
            //Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Debug.Log("画面外です");


        //Rect rc = new Rect(Vector2.zero, new Vector2(1000, 5000));
        //rc.Contains()
    }

    void OnTriggerEnter(Collider col)
    {

       

        if (col.gameObject.tag == "PlayerShield")
        {
            playerShield = col.gameObject.GetComponent<PlayerShield>();
            Destroy(gameObject);
            Debug.Log("敵の弾死亡");
        }

    }

}
