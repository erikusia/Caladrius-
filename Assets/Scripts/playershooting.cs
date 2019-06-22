using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playershooting : MonoBehaviour
{
    //弾prefab
    public GameObject bullet;

    //発射地点
    public Transform muzzle;

    //弾速度
    public float speed = 1000;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //複製
            GameObject bullets = Instantiate(bullet) as GameObject;
            Vector3 force;
            force = this.gameObject.transform.forward * speed;

            //rigidbodyに力を加えて発射
            bullets.GetComponent<Rigidbody>().AddForce(force);
            //弾丸の位置を調整
            bullets.transform.position = muzzle.position;
            Destroy(bullets, 3f);
        }
        
    }


}
