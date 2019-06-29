using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLimit : MonoBehaviour
{
    public static Vector3 MoveLimit = new Vector3(13.5f, 0.7f, 2f);
    
    public static Vector3 ClampPosition(Vector3 pos)
    {
        return new Vector3
            (
            Mathf.Clamp(pos.x,-MoveLimit.x,MoveLimit.x),
            Mathf.Clamp(pos.y,-MoveLimit.y,MoveLimit.y),
            Mathf.Clamp(pos.z,-MoveLimit.z,MoveLimit.z)
            );
    }

    public static Vector3 ClampRotation(Vector3 rot)
    {
        return new Vector3
            (
            Mathf.Clamp(rot.x,MoveLimit.x,MoveLimit.x),
            Mathf.Clamp(rot.y,-MoveLimit.y,MoveLimit.y)
            );
    }
}
