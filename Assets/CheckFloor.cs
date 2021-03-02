using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFloor : MonoBehaviour
{
    private PlayerControle player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<PlayerControle>();
    }
    
    void OnCollisionStay2D(Collision2D col){
        player.grounded = true;
         
    }
    void OnCollisionExit2D(Collision2D col){
        player.grounded = false;
    }
}
