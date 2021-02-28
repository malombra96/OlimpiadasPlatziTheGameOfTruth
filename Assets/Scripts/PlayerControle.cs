using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerControle : MonoBehaviour
{
    
    // Variables del movimiento del personaje
    public float jumpForce = 6f;
    public Rigidbody2D rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButtonDown(0) )
            Jump();
        
        print(Input.GetAxis("Horizontal"));
        Input.GetAxis("Cancel");

    }

    void Jump(){
        rigidBody.AddForce(Vector2.up* jumpForce, ForceMode2D.Impulse);
    }
}



