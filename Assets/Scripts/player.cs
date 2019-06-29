using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        character = GetComponent<Character>();
        StartCoroutine(PlayerShot());
    }

    // Update is called once per frame
    void Update()
    {
        MoveX = Input.GetAxisRaw("Horizontal") * speed;
        InputX = Input.GetAxisRaw("Horizontal");
        MoveZ = Input.GetAxisRaw("Vertical") * speed;
        Vector3 direction = new Vector3(MoveX, 0, MoveZ);

        timeCount += 1;


        transform.localPosition = PlayerLimit.ClampPosition(transform.localPosition);

        if (Input.GetMouseButton(0))
        {
            Debug.Log("推してます");

            //移動制限
            transform.localPosition = PlayerLimit.ClampPosition(transform.localPosition);
        }

        if (Input.GetKey(KeyCode.D)|| InputX >=0.8)
        {
            Debug.Log("D");
            zRotate = Mathf.Clamp(zRotate - adRotate * Time.frameCount, -40, 40);
            transform.eulerAngles = new Vector3(0, 0, zRotate);
        }
        if (Input.GetKey(KeyCode.A)||InputX <=-0.8)
        {
            Debug.Log("A");
            zRotate = Mathf.Clamp(zRotate + adRotate * Time.frameCount , -40, 40);
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
}
