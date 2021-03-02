using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public class PlayerControle : MonoBehaviour
{
   private Rigidbody2D rb;
   private Animator animator;
   //
   public LayerMask maskFloor;
   public Transform testFloor;
   public float ForceJump = 500f;
   private bool IsWalking;
   private bool IsFool = true;
   private float radio = 0.07f;


    // Start is called before the first frame update
    void Start(){
       rb = GetComponent<Rigidbody2D>();
       animator = GetComponent<Animator>();
    }

   void FixedUpdate(){

      IsFoor = Physics2D.OverlapCircle(){

   }

    // Update is called once per frame
    void Update(){

       if(Input.GetKeyDown(KeyCode.Space)){
          rb.AddForce(new Vector2(0, ForceJump));
       }
       if(Input.GetKeyDown(KeyCode.D)){
          animator.SetBool("IsWalking", true);
       }
      if(Input.GetKeyUp(KeyCode.D)){
         animator.SetBool("IsWalking", false);
      }
    }
      
        
}
