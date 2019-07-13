using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float movespeed;
    public float shotinterval;
    public GameObject bulletP;
    public GameObject bullet;
    public GameObject burstbullet;
    public GameObject circrebullets;
    public GameObject beem;

    //プレイヤー
    public void Shot(Transform origin)
    {
        Instantiate(bulletP, origin.position, origin.rotation);
    }

    //ビーム
    public void Beem(Transform origin)
    {
        Instantiate(beem, origin.position, origin.rotation);
    }

    //エネミー通常
    public void Shot0(Transform origin)
    {
        Instantiate(bullet, origin.position, origin.rotation);
        
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

    public void Move(Vector3 direcion)
    {
        GetComponent<Rigidbody>().velocity = direcion * movespeed;
    }

    public void Move2(Vector3 vector3)
    {
        GetComponent<GameObject>().transform.Translate(vector3);
    }
}
