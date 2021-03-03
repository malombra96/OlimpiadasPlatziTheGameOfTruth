using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVolumenManager : MonoBehaviour
{
    private AudioVolemeController[] audios;

    public float maxVolumen;

    public float currentVolumenleven;
    // Start is called before the first frame update
    void Start()
    {
        audios = FindObjectsOfType<AudioVolemeController>();
        ChangeGobalAudioVolumen();
    }

    private void Update()
    {
        ChangeGobalAudioVolumen();
    }

    public void ChangeGobalAudioVolumen()
    {
        if (currentVolumenleven >= maxVolumen)
        {
            currentVolumenleven = maxVolumen;
        }

        foreach (AudioVolemeController avc in audios)
        {
            avc.SetAudioLevel(currentVolumenleven);
        }
    }
}
