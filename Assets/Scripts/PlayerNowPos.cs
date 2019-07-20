using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNowPos : MonoBehaviour
{
    Transform player;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
    }
    public void Update()
    {
        if (player != null)
        {
            transform.LookAt(player);
        }
        else
        {
            transform.LookAt(null);
        }
       
    }
}
