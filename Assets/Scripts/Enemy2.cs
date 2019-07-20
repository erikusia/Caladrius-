using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    Character character;
    float dist;

    public Vector3 startpos;
    public Vector3 endpos;
    public float speed;
    float time;
    float distance;

    public int power = 1;

    public float hp = 1;

    Bullet playerBullet;

    PlayerShield playerShield;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        character = GetComponent<Character>();
        distance = Vector3.Distance(startpos, endpos);

        while (true)
        {
            yield return new WaitForSeconds(0.05f);
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform shotPosition = transform.GetChild(i);

                //shotPositionの位置方向で撃つ
                character.Shot0(shotPosition);
            }

            yield return new WaitForSeconds(character.shotinterval);
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        //Debug.Log(time);
        float nowpos = (time * speed) / distance;
        transform.position = Vector3.Lerp(startpos, endpos, nowpos);
    }

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "PlayerBullet")
        {
            playerBullet = col.gameObject.GetComponent<Bullet>();

            Debug.Log("敵Hit");
            // ヒットポイントを減らす
            hp = hp - playerBullet.power;
            if (hp <= 0)
            {
                Destroy(gameObject);
                Debug.Log("敵死亡");
            }
        }
        //if (col.gameObject.tag == "Beem")
        //{
        //    playerBullet = col.gameObject.GetComponent<Bullet>();

        //    Debug.Log("敵Hit");
        //    // ヒットポイントを減らす
        //    hp = hp - playerBullet.power;
        //    if (hp <= 0)
        //    {
        //        Destroy(gameObject);
        //        Debug.Log("敵死亡");
        //    }
        //}

        if (col.gameObject.tag == "PlayerShield")
        {
            playerShield = col.gameObject.GetComponent<PlayerShield>();
            Destroy(gameObject);
            Debug.Log("敵死亡");
        }

    }
}
