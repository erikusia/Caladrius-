using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playershot : MonoBehaviour
{
    Character character;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButton("Abutton")|| Input.GetMouseButton(0))
        {  
            StartCoroutine("PlayerShot");
        }
    }


}
