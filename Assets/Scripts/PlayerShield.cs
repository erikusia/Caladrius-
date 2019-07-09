﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{

      Character character;
    //public int power = 5;
    ParticleSystem m_particleSystem;

    public float shotinterval;
    public GameObject bulletP;

    List<ParticleSystem.Particle> m_exitList = new List<ParticleSystem.Particle>();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayerShot());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Shot(Transform origin)
    {
        Instantiate(bulletP, origin.position, origin.rotation);
    }

    IEnumerator PlayerShot()
    {
        while (true)
        {
            if (Input.GetKey(KeyCode.O))
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    Transform shotPosition = transform.GetChild(i);
                    Debug.Log("出てます");
                    //shotPositionの位置方向で
                    character.Shot(shotPosition);
                }
                yield return new WaitForSeconds(shotinterval);
            }
            yield return null;
        }
    }


    //void OnTriggerEnter(Collider col)
    //{
    //    //if (col.gameObject.tag == "Enemy")
    //    //{

    //    //    Destroy(gameObject);

    //    //}

    //    //if(col.gameObject.tag == "EnemyBullet")
    //    //{
    //    //    Destroy(gameObject);
    //    //}
    //}
}
