using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{

    private PlayerControle player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<PlayerControle>();
    
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        if(col.gameObject.tag == "Plataform")
        {
        player.grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Plataform")
        {
            player.grounded = false;
        }
    }

}
