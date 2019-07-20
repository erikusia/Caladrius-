using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeemDestroy : MonoBehaviour
{
    private void OnTriggerExit(Collider col)
    {
        Debug.Log(col.gameObject.name);
        GameObject beem = GameObject.FindWithTag("Beem");
        if(col.gameObject.tag == "Beem")
        {
            Destroy(col.gameObject);
        }
    }
}
