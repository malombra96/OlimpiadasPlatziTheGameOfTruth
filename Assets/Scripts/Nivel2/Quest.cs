using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public int questID;
    private QuestManager manager;
    public int exp;

    public string starText, completedText;

    public bool needsItem;
    public String itemNeeded;

    public bool needsEnemy;
    public string enemyName;
    public int numberOfEnemies;
    public int enemysKilled;
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (needsItem && manager.itemCollected.Equals(itemNeeded))
        {
            manager.itemCollected = null;
            CompletedQuests();
        }

        if (needsEnemy && manager.Enemykilled.Equals(enemyName))
        {
            manager.Enemykilled = null;
            enemysKilled++;
            if (enemysKilled >= numberOfEnemies)
            {
                CompletedQuests();
            }
        }
    }

    public void StartQuest()
    {
        manager = FindObjectOfType<QuestManager>();
        manager.ShowQuetsText(starText);
    }

    public void CompletedQuests()
    {
        manager.ShowQuetsText(completedText);
        manager.questsCompleted[questID] = true;
        gameObject.SetActive(false);
        GameObject.Find("Player").GetComponent<CharacterStats>().AddExperience(exp);
    }
}
