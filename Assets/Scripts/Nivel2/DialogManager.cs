using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogBox;
    public Text DialogText;
    public bool dialogActive;
    public string[] dialigLines;
    public int currentDialogLines;

    private PlayerController _playerController;
    void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogActive && Input.GetKeyDown(KeyCode.Space))
        {
            currentDialogLines++;
        }

        if (currentDialogLines >= dialigLines.Length)
        {
            dialogActive = false;
            dialogBox.SetActive(false);
            currentDialogLines = 0;
            _playerController.playerTalking = false;
        }
        else
        {
            DialogText.text = dialigLines[currentDialogLines];
        }
    }

    public void ShowDialog(String[] lines)
    {
        dialogActive = true;
        dialogBox.SetActive(true);
        currentDialogLines = 0;
        dialigLines = lines;
        _playerController.playerTalking = true;
    }
}
