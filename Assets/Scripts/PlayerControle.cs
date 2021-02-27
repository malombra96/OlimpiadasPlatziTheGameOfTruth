using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControle : MonoBehaviour

// Variables del movimiento del personaje
public float jumpForce = 6f;
Rigibody2D rigidBody;

private void Awake()
{
    rigidBody = GetComponet<Rigibody2D>();
}
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetJey(Keycode.Space) || Input.GetMouseButtonDown(0) )
            Jump();
        {
            
        }
    }

    void Jump(){
        rigidBody.AddForce(Vector2.up* jumpForce, ForceMode2D.Impulse);
    }
}
