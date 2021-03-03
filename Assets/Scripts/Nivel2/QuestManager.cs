using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public Quest[] quests;
    public bool[] questsCompleted;

    private DialogManager manager;

    public string itemCollected;

    public string Enemykilled;
    void Start()
    {
        questsCompleted = new bool[quests.Length];
        manager = FindObjectOfType<DialogManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowQuetsText(string questText)
    {
        string[] dialogLines = new string[]
        {
            questText
        };
        manager.ShowDialog(dialogLines);
    }
}
