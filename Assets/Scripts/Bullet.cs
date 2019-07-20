using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float BulletSpeed = 5;

    public float power = 1;
    new Rigidbody rigidbody;
    PlayerShield playerShield;

    // Start is called before the first frame update
    void Start()
    {
        
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rigidbody.velocity = transform.forward * BulletSpeed;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "PlayerShield")
        {
            playerShield = col.gameObject.GetComponent<PlayerShield>();
            Destroy(gameObject);
            Debug.Log("敵死亡");
        }
    }


}
