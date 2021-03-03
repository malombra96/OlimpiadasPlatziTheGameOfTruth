using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CircleCollider2D))]
public class QuestItem : MonoBehaviour
{
    public int questID;

    private QuestManager manager;

    public String itemName;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<QuestManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            if (manager.quests[questID].gameObject.activeInHierarchy &&
                !manager.questsCompleted[questID])
            {
                manager.itemCollected = itemName;
                gameObject.SetActive(false);
            }
        }
    }
}
