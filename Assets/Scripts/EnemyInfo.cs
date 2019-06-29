using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyInfo
{
    public float sec;
    public Vector3 pos;
    public GameObject pfbEnemy;

    public EnemyInfo(float sec, Vector3 pos, GameObject ptfEnemy)
    {
        this.sec = sec;
        this.pos = pos;
        this.pfbEnemy = ptfEnemy;
    }
}
