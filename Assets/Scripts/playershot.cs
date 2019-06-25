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

    private IEnumerable PlayerShot()
    {
        Debug.Log("コルーチンスタート");
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform shotPosition = transform.GetChild(i);
            Debug.Log("出てます");
            //shotPositionの位置方向で
            character.Shot(shotPosition);
        }

        yield return new WaitForSeconds(0.05f);
    }
}
