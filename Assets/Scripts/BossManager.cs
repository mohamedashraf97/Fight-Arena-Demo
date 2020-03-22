using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    public GameObject Bullet_Emitter;

    public GameObject Bullet;
    private float timer;
    private Transform target;

    void Start()
    {
    }
    void Update()
    {

        shoot();
        Bullet_Emitter = GameObject.FindGameObjectWithTag("Shooter2");

    }

    void shoot()
    {
        if (EnemyBoss.inRange == true)
        {
            timer += Time.deltaTime;

            if (timer > 2f && !PlayerMovement.dead)
            {
                GameObject Temporary_Bullet_Handler;
                Temporary_Bullet_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;
                Rigidbody2D Temporary_RigidBody;
                Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody2D>();
                Temporary_RigidBody.AddForce(Bullet_Emitter.transform.forward * 1000 * Time.deltaTime, ForceMode2D.Impulse);

                Destroy(Temporary_Bullet_Handler, 4.0f);
                timer = 0f;
            }
        }
    }

}
