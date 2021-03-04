using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControle : MonoBehaviour
{
   private Rigidbody2D rb;
   private Animator animator;
   //
   public LayerMask maskGround;
   public Transform testGround;
   public float ForceJump = 500f;
   public float speed = 10f;
   public float maxSpeed = 20f;
    public bool grounded;

//Estoy utilizando condiciones en el animator tipo entero son mas efectivos

 

   


    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() { 

        animator.SetFloat("Speed", Mathf.Abs (rb.velocity.x));
        animator.SetBool("Grounded", grounded);

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            animator.SetInteger("Status", 3);
            rb.AddForce(new Vector2(0, ForceJump));
           
        }



        float h = Input.GetAxis("Horizontal");
        rb.AddForce(Vector2.right * speed * h);

        if(rb.velocity.x > maxSpeed)
        {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        }
        if (rb.velocity.x > maxSpeed)
        {
            rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);
        }
        if (grounded)
        {
            if (h > 0.1f)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
                animator.SetInteger("State", 2);
            }
                
            if(h < -0.1f)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            } 
           
            
            
            if (h == 0) animator.SetInteger("State", 0);
        }
        Debug.Log(rb.velocity);
       
   
      
    }
 

}
