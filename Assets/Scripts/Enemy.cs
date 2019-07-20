using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Character character;
    public int rotspeed;
    public int power = 1;

    public float hp = 1;

    Score score;
    public float EnemyScore = 10.0f;

    Bullet playerBullet;
    PlayerShield playerShield;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        character = GetComponent<Character>();
        character.Move(transform.forward * -1);

        while (true)
        {
            yield return new WaitForSeconds(0.7f);
            for (int i=0;i<transform.childCount;i++)
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
        transform.Rotate(Vector3.forward * rotspeed);
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
                Score.score += EnemyScore;
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
            Score.score += EnemyScore;
            
        }

        if (col.gameObject.tag == "Beem")
        {
            playerBullet = col.gameObject.GetComponent<Bullet>();

            Debug.Log("敵に特殊ビームHit");
            // ヒットポイントを減らす
            hp = hp - playerBullet.power;
            if (hp <= 0)
            {
                Destroy(gameObject);
                Debug.Log("敵死亡");
                Score.score += EnemyScore*2;
            }
        }

    }

}
