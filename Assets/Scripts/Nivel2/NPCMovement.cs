using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public float speed = 1.5f;
    private Rigidbody2D npcrigibody;
    
    public bool isWalking, isTalking;
    
    public float walkTime = 1.5f;
    private float walkCounter;

    public float waitTime = 3;
    private float waitCounter;

    private Vector2[] walkingDirection =
    {
        new Vector2(1, 0),
        new Vector2(-1, 0),
        new Vector2(0, 1),
        new Vector2(0, -1)
    };

    private int curretDirection;

    public BoxCollider2D villageZone;
    private DialogManager manager;
    void Start()
    {
        manager = FindObjectOfType<DialogManager>();
        npcrigibody = GetComponent<Rigidbody2D>();
        waitCounter = waitTime;
        walkCounter = walkTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!manager.dialogActive)
        {
            isTalking = false;
        }
        
        if (isTalking)
        {
            StopWalking();
            return;
        }
        
        if (isWalking)
        {
            if (villageZone != null)
            {
                if (this.transform.position.x < villageZone.bounds.min.x || 
                    this.transform.position.x > villageZone.bounds.max.x ||
                    this.transform.position.y < villageZone.bounds.min.y ||
                    this.transform.position.y > villageZone.bounds.max.y)
                {
                    StopWalking();
                }
            }
            
            npcrigibody.velocity = walkingDirection[curretDirection] * speed;
            walkCounter -= Time.deltaTime;
            if (walkCounter < 0)
            {
                StopWalking();
            }
        }
        else
        {
            npcrigibody.velocity = Vector2.zero;
            waitCounter -= Time.deltaTime;
            if (waitCounter < 0)
            {
                StartWalking();
            }
        }
    }

    private void StartWalking()
    {
        isWalking = true;
        curretDirection = Random.Range(0, 4);
        walkCounter = walkTime;
    }

    private void StopWalking()
    {
        isWalking = false;
        waitCounter = waitTime;
        npcrigibody.velocity = Vector2.zero;
    }
}
