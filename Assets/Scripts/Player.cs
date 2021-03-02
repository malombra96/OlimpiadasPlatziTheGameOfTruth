using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
 private Rigidbody2D rb;
 private Animator animator;
 //
 public float speed = 2f;
public float maxSpeed = 10f; 
  public LayerMask maskFloor;
 public Transform testFloor;
 public float forceJump = 500f;
 private bool IsWalking;
 private bool IsFloor;
 private float radio = 0.07f;
 private bool jump2 = false;

    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
     
    // Update is called once per frame
    void Update(){

        if(Input.GetKeyDown(KeyCode.Space)){

            if(IsFloor || !jump2){
                rb.velocity = new Vector2(rb.velocity.x, forceJump);
            rb.AddForce(new Vector2(0, forceJump));
            
            if(!jump2 && !IsFloor){
                jump2 = true;
            }
            }
       }

       if(Input.GetKeyDown(KeyCode.D)){
          animator.SetBool("IsWalking", true);
       }
       
      if(Input.GetKeyUp(KeyCode.D)){
         animator.SetBool("IsWalking", false);
      }
       
    }
    void FixedUpdate(){   
        float h = Input.GetAxis("Horizontal");
        rb.AddForce(Vector2.right * speed * h);

        if(rb.velocity.x > maxSpeed){
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
            
        }
        }
    }    
   
 
