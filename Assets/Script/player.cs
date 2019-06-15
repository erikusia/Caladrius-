using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed = 5f;
    float MoveX = 0f;
    float MoveZ = 0f;

    Character character;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveX = Input.GetAxisRaw("Horizontal") * speed;
        MoveZ = Input.GetAxisRaw("Vertical") * speed;
        Vector3 direction = new Vector3(MoveX, 0, MoveZ);
        rb.constraints = RigidbodyConstraints.FreezePositionY;

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("推してます");
            for (int i = 0; i < transform.childCount; i++)
            {
                
                Transform shotPosition = transform.GetChild(i);
                Debug.Log("出てます");
                //shotPositionの位置方向で
                character.Shot(shotPosition);
            }
            //yield return new WaitForSeconds(character.shotinterval);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(MoveX, 0, MoveZ);
    }
}
