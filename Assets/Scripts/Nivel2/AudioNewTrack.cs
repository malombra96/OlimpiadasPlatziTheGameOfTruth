using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioNewTrack : MonoBehaviour
{
    private AudioManager _manager;

    public int newTrackID;

    public bool playOnStart;
    // Start is called before the first frame update
    void Start()
    {
        _manager = FindObjectOfType<AudioManager>();
        if (playOnStart)
        {
            _manager.PlayTrack(newTrackID);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            _manager.PlayTrack(newTrackID);
            gameObject.SetActive(false);
        }
    }

}
