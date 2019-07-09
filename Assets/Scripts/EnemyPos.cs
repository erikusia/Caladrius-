using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//target[0].transform.position-this.transform.position;

public class EnemyPos : MonoBehaviour
{
    GameObject[] targets;
    public float speed;
    float time;

    float targetPos=0;
    float nearDis=0;
    GameObject nearTarget = null;

    private void Start()
    {
        speed = 1.0f;
        StartCoroutine(enemyPos());
        
    }
    public void Update()
    {
        
    }

    IEnumerator enemyPos()
    {
        while (true)
        {
            nearDis = 0;
            time+= Time.deltaTime*speed;
            targets = GameObject.FindGameObjectsWithTag("Enemy");
            foreach(GameObject target in targets)
            {
                targetPos = Vector3.Distance(target.transform.position, transform.position);
                //Debug.Log("target"+target);
                //Debug.Log("targetPos"+targetPos);
                //Debug.Log("nearDis"+nearDis);
                if (nearDis ==0  || nearDis >= targetPos)
                {
                    nearDis = targetPos;
                    nearTarget = target;
                }
                Debug.Log(nearTarget);

            }
            //現在の回転情報と、ターゲット方向の回転情報を補完する
            if (nearTarget != null)
            {
                Quaternion quaternion = Quaternion.LookRotation(nearTarget.transform.position - transform.position);
                this.transform.rotation = Quaternion.Slerp(transform.rotation, quaternion, time);
            }
            else 
            {
                break;
            }

            yield return null;
        }
    }
}
