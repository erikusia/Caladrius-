using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNowPos : MonoBehaviour
{
    public Transform player;

    private void Start()
    {
        
    }
    public void Update()
    {
        Transform target = player;
        transform.LookAt(player);
    }
}
