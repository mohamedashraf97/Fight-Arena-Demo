using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform target;

    private float speed = 4.5f;
    private float startingDistance = 8f;
    private float stoppingDistance = 2f;
    public Rigidbody2D rb;
    public static bool inRange = false;
    Vector2 targetPos;
    public static int enemyHealth = 5;
    public static bool dead = false ;
    void Start()
    {
       target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerMovement.dead)
        {
            if (Vector2.Distance(transform.position, target.position) < startingDistance && Vector2.Distance(transform.position, target.position) > stoppingDistance)
            {
                inRange = true;
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

                targetPos = target.position;

                Vector2 lookDir = targetPos - rb.position;
                float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90f;
                rb.rotation = angle;

            }
            else
            {
                inRange = false;
            }
        }
        
      dead = false ;

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        if (col.gameObject.CompareTag("Bullet"))
        {
            enemyHealth--;
            if(enemyHealth <= 0)
            {
                dead = true ;
                Destroy(gameObject);
            }
        }
        
        
    }
}
