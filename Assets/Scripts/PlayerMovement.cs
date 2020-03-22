using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float movSpeed = 6f;
    public static  int health = 3;
    public static bool dead ;
       public GameObject Bullet_Emitter1;

    public GameObject Bullet;
    Vector2 movement;
    public Rigidbody2D rb;
    public Animator anim ;
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        rb.MovePosition(rb.position + movement * movSpeed * Time.fixedDeltaTime);
        anim.SetFloat("Horizontal",movement.x);
        anim.SetFloat("Vertical",movement.y);
        anim.SetFloat("Magnitude",movement.magnitude);
        shootPlayer();


    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Bullet"))
        {
            health--;
            if(health ==0)
            {
            dead = true ;
            Debug.Log("dead");
            Destroy(gameObject);
            }
        }
        else if (col.gameObject.CompareTag("Enemy"))
        {
            dead = true ;
            Debug.Log("dead");
            Destroy(gameObject);
        }
         else if (col.gameObject.CompareTag("Boss"))
        {
            dead = true ;
            Debug.Log("dead");
            Destroy(gameObject);
        }
        
    }
        void shootPlayer()
    {
        if (Input.GetKeyDown("space"))
        {
           
                GameObject Temporary_Bullet_Handler;
                Temporary_Bullet_Handler = Instantiate(Bullet, Bullet_Emitter1.transform.position, Bullet_Emitter1.transform.rotation) as GameObject;
                Rigidbody2D Temporary_RigidBody;
                Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody2D>();
                Temporary_RigidBody.AddForce(Bullet_Emitter1.transform.up * 1000 * Time.deltaTime, ForceMode2D.Impulse);

                Destroy(Temporary_Bullet_Handler, 4.0f);
            
        }
    }
}
