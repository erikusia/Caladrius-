using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public float speed = 5f;
    float MoveX;
    float MoveZ;

    Character character;
    Rigidbody rb;
    private int timeCount;

    public float hp = 1;

    Bullet enemyBullet;
    Enemy AttackEnemy;

    private Slider playerHPSlider;
    public GameObject[] playerIcons;

    public int destroyCount = 0;

    public bool isMuteki = false;

   // public float interval = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        character = GetComponent<Character>();
      //  StartCoroutine("Blink");
    }

    //IEnumerator Blink()
    //{
    //    while (true)
    //    {
    //        var renderComponent = GetComponent<Renderer>();
    //        renderComponent.enabled = !renderComponent.enabled;
    //        yield return new WaitForSeconds(interval);
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        MoveX = Input.GetAxisRaw("Horizontal") * speed;
        MoveZ = Input.GetAxisRaw("Vertical") * speed;
        Vector3 direction = new Vector3(MoveX, 0, MoveZ);

        timeCount += 1;

        //移動制限
        transform.localPosition = PlayerLimit.ClampPosition(transform.localPosition);


        if (Input.GetMouseButton(0) || Input.GetButton("Abutton"))
        {
            Debug.Log("推してます");

            if (timeCount % 2f == 0)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    Transform shotPosition = transform.GetChild(i);
                    Debug.Log("出てます");
                    //shotPositionの位置方向で
                    character.Shot(shotPosition);
                    
                }
            }

        }
    }



    void FixedUpdate()
    {
       rb.velocity = new Vector3(MoveX, 0, MoveZ);

    }


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Enemy") && isMuteki == false)
        {

            Invoke("Retry", 0.01f);


            if (col.gameObject.tag == "Enemy")
            {
                AttackEnemy = col.gameObject.GetComponent<Enemy>();
                // ヒットポイントを減らす
                hp = hp - AttackEnemy.power;

                Destroy(col.gameObject);

                if (hp == 2)
                {

                    Debug.Log("敵からダメージを喰らっている");
                    destroyCount += 1;

                    UpdatePlayerIcons();

                }

                if (hp == 1)
                {
                    Debug.Log("敵からダメージを喰らっている2");
                    destroyCount += 1;

                    UpdatePlayerIcons();
                }

                if (hp <= 0)
                {
                    Debug.Log("敵からダメージを喰らっている3");
                    //HPが0となったら破壊された回数を1増やす
                    destroyCount += 1;

                    // 命令ブロック（メソッド）を呼び出す。
                    UpdatePlayerIcons();

                    Destroy(gameObject);
                    Debug.Log("敵に当たり死亡");
                }


            }

         
        }

        if (col.gameObject.CompareTag("EnemyBullet") && isMuteki == false)
        {


            Invoke("Retry", 0.01f);


            if (col.gameObject.tag == "EnemyBullet")
            {
                enemyBullet = col.gameObject.GetComponent<Bullet>();
                // ヒットポイントを減らす
                hp = hp - enemyBullet.power;

                Destroy(col.gameObject);

                if (hp == 2)
                {

                    Debug.Log("ダメージを喰らっている");
                    destroyCount += 1;

                    UpdatePlayerIcons();

                }

                if (hp == 1)
                {
                    Debug.Log("ダメージを喰らっている2");
                    destroyCount += 1;

                    UpdatePlayerIcons();
                }

                if (hp <= 0)
                {
                    Debug.Log("ダメージを喰らっている3");
                    //HPが0となったら破壊された回数を1増やす
                    destroyCount += 1;

                    // 命令ブロック（メソッド）を呼び出す。
                    UpdatePlayerIcons();

                    Destroy(gameObject);
                    Debug.Log("死亡");
                }


            }

        }


    }

    void UpdatePlayerIcons()
    {
        for(int i = 0; i < playerIcons.Length; i++)
        {
            if(destroyCount <= i)
            {
                playerIcons[i].SetActive(true);
            }
            else
            {
                playerIcons[i].SetActive(false);
            }
        }
    }

    void Retry()
    {
        this.gameObject.SetActive(true);
        
        //無敵時間
        isMuteki = true;
        Invoke("MutekiOff", 3.0f);
    }

    void MutekiOff()
    {
        isMuteki = false;
    }

}
