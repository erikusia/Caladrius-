using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float movespeed;
    public float shotinterval;
    public GameObject bullet;

    public void Shot(Transform origin)
    {
        Instantiate(bullet, origin.position, origin.rotation);
        
    }

    public void Move(Vector3 direcion)
    {
        GetComponent<Rigidbody>().velocity = direcion * movespeed;
    }
}
