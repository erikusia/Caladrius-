using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed = 5f;
    float MoveX = 0f;
    float MoveZ = 0f;

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
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(MoveX, 0, MoveZ);
    }
}
