using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVolemeController : MonoBehaviour
{
    private AudioSource _audioSource;

    private float currentAudioLevel;

    public float defaulAudioLevel;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAudioLevel(float newVolumen)
    {
        if (_audioSource == null)
        {
            _audioSource = GetComponent<AudioSource>();
        }

        currentAudioLevel = defaulAudioLevel * newVolumen;
        _audioSource.volume = currentAudioLevel;
    }
}
