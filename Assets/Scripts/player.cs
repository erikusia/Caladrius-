using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public float speed = 5f;

    float MoveX = 0f;
    float MoveZ = 0f;
    float InputX;
    public int rotspeed;
    public float adRotate = 10;


    public float shotinterval;
    Character character;
    Rigidbody rb;
    private int timeCount;
    float zRotate = 0;


    Bullet enemyBullet;
    Enemy AttackEnemy;
    public int hp = 3;


    GameObject[] playerIcons;

    public int destroyCount = 0;

    public bool isMuteki = false;

    public float interval = 0.1f;

    public AudioClip sound1;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        character = GetComponent<Character>();
        StartCoroutine(PlayerShot());
        audioSource = GetComponent<AudioSource>();
        playerIcons = GameObject.FindGameObjectsWithTag("PlayerHp");
    }

    IEnumerator Blink()
    {
        for (int i = 0; i < 30; i++)
        {
            var renderComponent = GetComponent<Renderer>();
            renderComponent.enabled = !renderComponent.enabled;
            yield return new WaitForSeconds(interval);
        }
    }

    void Update()
    {
        MoveX = Input.GetAxisRaw("Horizontal") * speed;
        InputX = Input.GetAxisRaw("Horizontal");
        MoveZ = Input.GetAxisRaw("Vertical") * speed;
        Vector3 direction = new Vector3(MoveX, 0, MoveZ);

        timeCount += 1;


        transform.localPosition = PlayerLimit.ClampPosition(transform.localPosition);

        //transform.position = Vector3.Lerp();

        if (Input.GetMouseButton(0))
        {
            Debug.Log("推してます");

            //移動制限
            transform.localPosition = PlayerLimit.ClampPosition(transform.localPosition);
        }

        if (Input.GetKey(KeyCode.D) || InputX >= 0.8)
        {
            Debug.Log("D");
            zRotate = Mathf.Clamp(zRotate - adRotate * Time.frameCount, -40, 40);
            transform.eulerAngles = new Vector3(0, 0, zRotate);
        }
        else if (Input.GetKey(KeyCode.A) || InputX <= -0.8)
        {
            Debug.Log("A");
            zRotate = Mathf.Clamp(zRotate + adRotate * Time.frameCount, -40, 40);
            transform.eulerAngles = new Vector3(0, 0, zRotate);
        }
        else
        {
            zRotate = Mathf.Clamp(0, 0, 0);
            transform.eulerAngles = new Vector3(0, 0, zRotate);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(MoveX, 0, MoveZ);
    }


    IEnumerator PlayerShot()
    {
        while (true)
        {
            if (Input.GetMouseButton(0) || Input.GetButton("Abutton"))
            {
                for (int i = 0; i < 3; i++)
                {
                    Transform shotPosition = transform.GetChild(i);
                    Debug.Log("出てます");
                    //shotPositionの位置方向で
                    character.Shot(shotPosition);
                }
                yield return new WaitForSeconds(shotinterval);
                audioSource.PlayOneShot(sound1);
            }
            yield return null;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (isMuteki == false)
        {

            if (col.gameObject.CompareTag("Enemy"))
            {
                Invoke("Retry", 0.01f);
                AttackEnemy = col.gameObject.GetComponent<Enemy>();
                // ヒットポイントを減らす
                hp = hp - AttackEnemy.power;
                Destroy(col.gameObject);

                if (hp == 2)
                {

                    Debug.Log("敵からダメージを喰らっている");
                    destroyCount += 1;
                    StartCoroutine("Blink");
                    UpdatePlayerIcons();

                }

                if (hp == 1)
                {
                    Debug.Log("敵からダメージを喰らっている2");
                    destroyCount += 1;
                    StartCoroutine("Blink");
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

                    SceneManager.LoadScene("GameOver");
                }
            }

            else if (col.gameObject.CompareTag("EnemyBullet"))
            {
                Invoke("Retry", 0.01f);
                enemyBullet = col.gameObject.GetComponent<Bullet>();
                // ヒットポイントを減らす
                hp = hp - enemyBullet.power;
                Destroy(col.gameObject);

                if (hp == 2)
                {

                    Debug.Log("敵からダメージを喰らっている");
                    destroyCount += 1;
                    StartCoroutine("Blink");
                    UpdatePlayerIcons();

                }

                if (hp == 1)
                {
                    Debug.Log("敵からダメージを喰らっている2");
                    destroyCount += 1;
                    StartCoroutine("Blink");
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

                    SceneManager.LoadScene("GameOver");
                }
            }
        }    
    }

       
    void UpdatePlayerIcons()
    {
        for (int i = 0; i < playerIcons.Length; i++)
        {

            if (destroyCount <= i)
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
