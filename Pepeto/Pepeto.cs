using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Pepeto : MonoBehaviour {
    public Rigidbody2D myRigidBody;
    Animator animator;
    float velocity;
    float JumpForce;
    float jumpdelay;
    float direction;
    public bool movingRight;
    public bool jumping;
    bool lookinRight;


    // Use this for initialization
    void Start() {
        myRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        velocity = 5f;
        JumpForce = 10;
        jumping = false;
        jumpdelay = 0;
    }

    // Update is called once per frame
    void Update() {
        jumpdelay += Time.deltaTime;
        animator.SetBool("walking", false);

        //Comienza Controles Android
        
        direction = CrossPlatformInputManager.GetAxis("Horizontal");

        myRigidBody.velocity = new Vector2(direction * velocity, myRigidBody.velocity.y);

        if (myRigidBody.velocity.x < 0f && direction == -1f)
        {
            lookinRight = false;
            animator.SetBool("walking", true);
        }

        if (myRigidBody.velocity.x >= 0f && direction == 1f)
        {
            lookinRight = true;
            animator.SetBool("walking", true);

        }

        if (!lookinRight)
        {
            transform.localScale = new Vector3(-6f, transform.localScale.y, transform.localScale.z);
        }

        if (lookinRight)
        {
            transform.localScale = new Vector3(6f, transform.localScale.y, transform.localScale.z);
        }

        if (CrossPlatformInputManager.GetButtonDown("Jump") && !jumping && jumpdelay >= 0.65f)
        {
            myRigidBody.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            jumping = true;
            jumpdelay = 0f;
        }
        
        
        //Termina Controles Android

        //Comienza Controles StandAlone
        /*
               if (Input.GetKey(KeyCode.RightArrow))
               {
                   lookinRight = true;
                   transform.localScale = new Vector3(6f, transform.localScale.y, transform.localScale.z);
                   transform.Translate (Vector2.right * velocity * Time.deltaTime);
                   movingRight = true;
                   animator.SetBool("walking", true);
               }
               else
               {
                   lookinRight = false;
               }

               if (Input.GetKey(KeyCode.LeftArrow))
               {
                   Flip();
                   transform.Translate(Vector2.right * -velocity * Time.deltaTime);
                   movingRight = false;
                   animator.SetBool("walking", true);
               }

       if (Input.GetKeyDown(KeyCode.Space) && !jumping && jumpdelay >= 0.65f)
               {
                   myRigidBody.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
                   jumping = true;
                   jumpdelay = 0f;
               }
        */
       //Termina controles StandAlone
               
   }
   

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Ground")
            {
                jumping = false;
            }
        }

         void Flip()
         {
             if (!lookinRight)
             {
                 transform.localScale = new Vector3(-6f, transform.localScale.y, transform.localScale.z);
             }
         }

    }

