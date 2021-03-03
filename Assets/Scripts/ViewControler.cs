using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewControler : MonoBehaviour
{
    public List<Sprite> images;
    public int caso;
    public GameObject btnrigth;
    public GameObject btnleft;
    public GameObject container;
    void Start()
    {
        
    }

    public void Right()
    {
        caso = (caso != 1) ? caso += 1 : caso = 1;
        if (caso == 1)
        {
            btnrigth.SetActive(false);
            btnleft.SetActive(true);
        }
        else
        {
            btnrigth.SetActive(true);
            btnleft.SetActive(true);
        }
        MoveRight();
    }
    
    public void Left()
    {
        caso = (caso != 0) ? caso -= 1: caso = 0;
        if (caso == 0)
        {
            btnleft.SetActive(false);
            btnrigth.SetActive(true);
        }
        else
        {
            btnrigth.SetActive(true);
            btnleft.SetActive(true);
        }
        MoveLeft();
    }

    public void MoveRight()
    {
        iTween.MoveTo(
            container,
            iTween.Hash(
                "position", new Vector3(-403.3f, 0, 0f),
                "looktarget", Camera.main,
                "easeType", iTween.EaseType.easeOutExpo,
                "time", 1f,
                "islocal", true
            )
        );
    }
    
    public void MoveLeft()
    {
        iTween.MoveTo(
            container,
            iTween.Hash(
                "position", new Vector3(401.91f, 0, 0f),
                "looktarget", Camera.main,
                "easeType", iTween.EaseType.easeOutExpo,
                "time", 1f,
                "islocal", true
            )
        );
    }
    
    
}
