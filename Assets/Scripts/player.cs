using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed = 5f;
<<<<<<< HEAD
    float MoveX = 0f;
    float MoveZ = 0f;
    public int rotspeed;
=======
    float MoveX;
    float MoveZ;
>>>>>>> master

    public float shotinterval;
    Character character;
    Rigidbody rb;
    private int timeCount;

    public Vector3 rot;

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
        MoveZ = Input.GetAxisRaw("Vertical") * speed;
        Vector3 direction = new Vector3(MoveX, 0, MoveZ);

        timeCount += 1;

<<<<<<< HEAD
        transform.localPosition = PlayerLimit.ClampPosition(transform.localPosition);

        if (Input.GetMouseButton(0))
        {
            Debug.Log("推してます");
=======
        //移動制限
        transform.localPosition = PlayerLimit.ClampPosition(transform.localPosition);
    }

    void FixedUpdate()
    {
       rb.velocity = new Vector3(MoveX, 0, MoveZ);
    }
>>>>>>> master

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
<<<<<<< HEAD

    void FixedUpdate()
    {
       rb.velocity = new Vector3(MoveX, 0, MoveZ);


    }
=======
>>>>>>> master
}
