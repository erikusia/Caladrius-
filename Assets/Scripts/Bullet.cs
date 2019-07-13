using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float BulletSpeed = 5;

    public int power = 1;

    PlayerShield playerShield;
    new Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = transform.forward * BulletSpeed;
    }

    void OnTriggerEnter(Collider col)
    {

        if (gameObject.tag != "PlayerBullet")
        {
            if (col.gameObject.tag == "PlayerShield")
            {
                playerShield = col.gameObject.GetComponent<PlayerShield>();
                Destroy(gameObject);
                Debug.Log("敵の弾死亡");
            }
        }


    }

}
