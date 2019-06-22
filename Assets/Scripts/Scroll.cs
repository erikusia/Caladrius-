using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    int posZ;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        posZ++;

        transform.position = new Vector3(0, 0, -posZ*0.3f);

    }
}
