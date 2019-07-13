using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float movespeed;
    public float shotinterval;
    public GameObject PlayerBullet;
    public GameObject EnemyBullet;
    public GameObject burstbullet;
    public GameObject circrebullets;
<<<<<<< HEAD
    public GameObject beem;
=======
    public GameObject SpecialBullet;
>>>>>>> 51f750cba4c335dec6a9170a2e6067d78f40b929

    //プレイヤー
    public void Shot(Transform origin)
    {
        Instantiate(PlayerBullet, origin.position, origin.rotation);
    }

    //ビーム
    public void Beem(Transform origin)
    {
        Instantiate(beem, origin.position, origin.rotation);
    }

    //エネミー通常
    public void Shot0(Transform origin)
    {
        Instantiate(EnemyBullet, origin.position, origin.rotation);
        
    }

    //エネミー左右拡散
    public void Shot1(Transform origin)
    {
        Instantiate(burstbullet, origin.position, origin.rotation);
    }

    //エネミー円状に拡散
    public void Shot2(Transform origin)
    {
        Instantiate(circrebullets, origin.position, origin.rotation);
    }

    public void specialShot(Transform origin)
    {
        Instantiate(SpecialBullet, origin.position, origin.rotation);
    }



    public void Move(Vector3 direcion)
    {
        GetComponent<Rigidbody>().velocity = direcion * movespeed;
    }

    public void Move2(Vector3 vector3)
    {
        GetComponent<GameObject>().transform.Translate(vector3);
    }
}
