using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLimit : MonoBehaviour
{

    public static Vector3 MoveLimit = new Vector3(9.2f, 0,7.2f);


    //public static Vector3 ClampRotation(Quaternion rot)
    //{
    //    return new Vector3
    //        (
    //        Mathf.Clamp(rot.x, MoveLimit.x, MoveLimit.x),
    //        Mathf.Clamp(rot.y, -MoveLimit.y, MoveLimit.y)
    //        );
    //}

    public static Vector3 ClampPosition(Vector3 pos)
    {
        return new Vector3
        (
            Mathf.Clamp( pos.x,-MoveLimit.x,MoveLimit.x),
            Mathf.Clamp(pos.y,-MoveLimit.y,MoveLimit.y),
            Mathf.Clamp(pos.z, -MoveLimit.z, MoveLimit.z)
        );

    }
}
