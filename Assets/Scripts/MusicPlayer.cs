using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    AudioSource audioSorurce;

    void Start()
    {
        DontDestroyOnLoad(this);
        audioSorurce = GetComponent<AudioSource>();
        audioSorurce.volume = PlayerPrefsController.GetMasterVOlume();
    }

    public void SetVolume(float volume)
    {
        audioSorurce.volume = volume;
    }
}
