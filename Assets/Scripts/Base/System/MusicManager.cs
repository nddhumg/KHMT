using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

[Serializable]
public class MusicData {
    public AudioClip clip;
    public float volume;
}
public class MusicManager : PersistentSingleton<MusicManager>
{
    [SerializeField] protected AudioSource musicAudio;
    [SerializeField] protected AudioSource soundAudio;
    protected bool isMuteMusic;
    protected bool isMuteSound;


    [SerializeField] protected float fadeDuration;

    public float VolumeMusic => musicAudio.volume;
    public float VolumeSound => soundAudio.volume;
    public bool IsMuteMusic => isMuteMusic;
    public bool IsMuteSound => isMuteSound;
    public void PlayerMusic(MusicData data)
    {
        musicAudio.clip = data.clip;
        musicAudio.volume = data.volume;
        musicAudio.Play();
    }

    public void ChangeVolumnMusic(float value) {
        musicAudio.volume = value;
    }

    public void ChangeVolumnSound(float value) { 
        soundAudio.volume = value;
    }

    public void ChangeMuteMusic()
    {
        musicAudio.mute = !isMuteMusic;
        isMuteMusic = !isMuteMusic;
    }

    public void ChangeMuteSound()
    {
        soundAudio.mute = !isMuteSound;
        isMuteSound = !isMuteSound;
    }

    protected IEnumerator SwitchMusic(MusicData data)
    {
        float startVolume = musicAudio.volume;

        for (float t = 0; t < fadeDuration/2; t += Time.deltaTime)
        {
            musicAudio.volume = Mathf.Lerp(startVolume, 0, t / fadeDuration);
            yield return null;
        }

        musicAudio.volume = 0;

        musicAudio.clip = data.clip;
        musicAudio.Play();

        for (float t = 0; t < fadeDuration/2; t += Time.deltaTime)
        {
            musicAudio.volume = Mathf.Lerp(0, data.volume, t / fadeDuration);
            yield return null;
        }

        musicAudio.volume = data.volume;
    }

    public void PlaySound(MusicData data)
    {
        musicAudio.clip = data.clip;
        musicAudio.volume = data.volume;
        musicAudio.Play();
    }
}
