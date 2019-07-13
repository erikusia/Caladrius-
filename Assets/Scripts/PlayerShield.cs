using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{

    Character character;
    player player;
    //public int power = 5;
    ParticleSystem m_particleSystem;

    public float shotinterval;
    public GameObject bulletP;

    Vector3 lot;

    List<ParticleSystem.Particle> m_exitList = new List<ParticleSystem.Particle>();

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponentInParent<Character>();
        player = GetComponent<player>();

        lot = transform.eulerAngles;

        //StartCoroutine(PlayerShot());
    }

    // Update is called once per frame
    void Update()
    {


    }

    void LateUpdate()
    {
        transform.eulerAngles = lot;
    }

    //IEnumerator PlayerShot()
    //{
    //    while (true)
    //    {
    //        if (Input.GetKey(KeyCode.O))
    //        {
    //            for (int i = 0; i < 3; i++)
    //            {
    //                Transform shotPosition = transform.GetChild(i);
    //                Debug.Log("出てます");
    //                //shotPositionの位置方向で
    //                character.Shot(shotPosition);
    //            }
    //            yield return new WaitForSeconds(shotinterval);
    //        }
    //        yield return null;
    //    }
    //}


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log(gameObject);
            //Destroy(gameObject);

        }

        if (col.gameObject.tag == "EnemyBullet")
        {
            Debug.Log(gameObject);
           // Destroy(gameObject);
        }
    }
}
