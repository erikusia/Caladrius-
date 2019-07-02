using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingLaser : MonoBehaviour
{
    //Rigidbodyを入れる変数
    Rigidbody rigid;
    //速度
    Vector3 velocity;
    //発射するときの初期位置
    Vector3 position;
    // 加速度
    public Vector3 acceleration;
    // ターゲットをセットする
    public Transform target;
    // 着弾時間
    float period = 2f;

    public float Power = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        // 初期位置をposionに格納
        position = transform.position;
        // rigidbody取得
        rigid = this.GetComponent<Rigidbody>();

        // 初速をランダムで与える
        velocity = new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f), 0);

    }

    // Update is called once per frame
    void Update()
    {
        acceleration = Vector3.zero;

        //ターゲットと自分自身の差
        var diff = target.position - transform.position;

        //加速度を求めてる
        acceleration += (diff - velocity * period) * 2f
                        / (period * period);


        ////加速度が一定以上だと追尾を弱くする
        //if (acceleration.magnitude > 100f)
        //{
        //    acceleration = acceleration.normalized * 100f;
        //}

        // 着弾時間を徐々に減らしていく
        period -= Time.deltaTime;

        // 速度の計算
        velocity += acceleration * Time.deltaTime;
    }

    void FixedUpdate()
    {
        // 移動処理
        rigid.MovePosition(transform.position + velocity * Time.deltaTime);
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            // 何かに当たったら自分自身を削除
            Destroy(this.gameObject);
        }
        

    }
}
