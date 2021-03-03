using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speet = 4.0f;  // velocidad de movimiento

    //private float currentSpeed;
    
    private Animator animatorPlayer; //para obtener el grafo de animacion del player 

    // variables para manejar el grafo del animador 
    private const string HORIZONTAL = "Horizontal";    
    private const string VERTICAL = "Vertical";
    private const string LASTHORIZONTAL = "LastHorizontal";
    private const string LASTVERTICAL = "LastVertical";
    private const string WALKINGSTATE = "Walking";
    private const string ATTACKING = "Attacking";

    public static bool playerCreated;
    
    private bool walking = false;
    
    public Vector2 lastMovement = Vector2.zero;

    private Rigidbody2D _rigidbody2D;

    public string nextPlacesName;

    private bool attacking = false;
    public float attackTime;
    private float attackTimeCount;
    public bool playerTalking;
    private SFXManager _sfxManager;
    void Start()
    {
        _sfxManager = FindObjectOfType<SFXManager>();
        animatorPlayer = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        
        
        if (!playerCreated)
        {
            playerCreated = true;
            DontDestroyOnLoad(this.transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        playerTalking = false;
        lastMovement = new Vector2(1,0);
    }
    void Update()
    {
        // s = v*t;
        // movimiento en el eje x
        if (playerTalking)
        {
            _rigidbody2D.velocity = Vector2.zero;
            return;
        }

        walking = false;

        if (Input.GetMouseButtonDown(0))
        {
            attacking = true;
            attackTimeCount = attackTime;
            _rigidbody2D.velocity = Vector2.zero;
            animatorPlayer.SetBool(ATTACKING, true);
            _sfxManager.playerAttack.Play();
        }

        if (attacking)
        {
            attackTimeCount -= Time.deltaTime;
            if (attackTimeCount < 0)
            {
                attacking = false;
                animatorPlayer.SetBool(ATTACKING, false);   
            }
        }
        else
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f ||
                Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f)
            {
                walking = true;
                
                lastMovement = new Vector2(
                    Input.GetAxisRaw("Horizontal"),
                    Input.GetAxisRaw("Vertical"));
                
                _rigidbody2D.velocity = lastMovement.normalized * speet * Time.deltaTime;
                
            }
            /*
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f)
            {
                //this.transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * speet *Time.deltaTime,
                //                                   0,
                //                             0));
                _rigidbody2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * currentSpeed *Time.deltaTime,
                    _rigidbody2D.velocity.y);
                walking = true;
                lastMovement = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
            }

            movimiento en el eje y
        
            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f)
            {
                this.transform.Translate(new Vector3(0,
                    Input.GetAxisRaw("Vertical") * speet *Time.deltaTime,
                    0));
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x,
                    Input.GetAxisRaw("Vertical") * currentSpeed *Time.deltaTime);
                walking = true;
                lastMovement = new Vector2(0, Input.GetAxisRaw("Vertical"));
            }
            // movimiento en diagonal 
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5 && 
                Mathf.Abs(Input.GetAxisRaw("Vertical"))  > 0.5)
            {
                currentSpeed = speet / Mathf.Sqrt(2);
            }
            else
            {
                currentSpeed = speet;
            }*/
        }

        if (!walking)
        {_rigidbody2D.velocity = Vector2.zero;
            
        }
        
        animatorPlayer.SetFloat(HORIZONTAL, Input.GetAxisRaw("Horizontal"));
        animatorPlayer.SetFloat(VERTICAL, Input.GetAxisRaw("Vertical"));
        animatorPlayer.SetBool(WALKINGSTATE, walking);
        animatorPlayer.SetFloat(LASTHORIZONTAL, lastMovement.x);
        animatorPlayer.SetFloat(LASTVERTICAL, lastMovement.y);
    }
}
