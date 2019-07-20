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

    PlayerShield playerShield;

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


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            
                playerShield = col.gameObject.GetComponent<PlayerShield>();

                Debug.Log(col);
            Destroy(col.gameObject);

        }

        if (col.gameObject.tag == "EnemyBullet")
        {
            Debug.Log(gameObject);

            playerShield = col.gameObject.GetComponent<PlayerShield>();

            Debug.Log(col);
            Destroy(col.gameObject);
        }
    }
}
