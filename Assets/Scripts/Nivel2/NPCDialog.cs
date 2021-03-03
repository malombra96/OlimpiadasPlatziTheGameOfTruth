using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialog : MonoBehaviour
{
    public string[] dialog;
    private DialogManager manager;
    private bool playerInTheZone;
    
    void Start()
    {
        manager = FindObjectOfType<DialogManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInTheZone && Input.GetKeyDown(KeyCode.Return))
        {
            manager.ShowDialog(dialog);
            if (gameObject.GetComponentInParent<NPCMovement>() != null)
            {
                gameObject.GetComponentInParent<NPCMovement>().isTalking = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            playerInTheZone = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            playerInTheZone = false;
            
        }
    }
}
