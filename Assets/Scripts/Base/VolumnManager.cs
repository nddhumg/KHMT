using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof(AudioSource))]
public class VolumnManager : SpawnPool<VolumnManager>
{
    protected AudioSource musicAudio;

    private void Start()
    {
        musicAudio = GetComponent<AudioSource>();
    }

    public void PlayMusic(AudioClip music) {
        musicAudio.clip = music;
        musicAudio.Play();
    }

    public void Mute(bool isMute) { 
        musicAudio.mute = isMute;
    }

    public void ChangedMusic(AudioClip music) { 
        
    }

}
