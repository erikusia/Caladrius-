using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float BulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward.normalized * BulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<Renderer>().isVisible)
        {
            //Debug.Log("画面外です");
            //Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Debug.Log("画面外です");

        //Rect rc = new Rect(Vector2.zero, new Vector2(1000, 5000));
        //rc.Contains()
    }
}
