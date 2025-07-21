using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

[Serializable]
public class MusicData {
    public MusicKey key;
    public AudioClip clip;
    [Range(0,1)]public float volume;
}
public class MusicManager : PersistentSingleton<MusicManager>
{
    [SerializeField] protected AudioSource musicAudio;
    [SerializeField] protected AudioSource soundAudio;
    [SerializeField] protected MusicContainer musicContainer;

    [SerializeField] protected float fadeDuration;
    private Dictionary<MusicKey, float> lastPlayTime = new();
    private float coolDown = 0.3f;

    public float VolumeMusic => musicAudio.volume;
    public float VolumeSound => soundAudio.volume;
    public bool IsMuteMusic => musicAudio.mute;
    public bool IsMuteSound => soundAudio.mute;

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
        musicAudio.mute = !musicAudio.mute;
    }

    public void ChangeMuteSound()
    {
        soundAudio.mute = !soundAudio.mute;
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

    public void PlayMusic(MusicKey key)
    {
        MusicData musicData = musicContainer.GetMusicData(key);
        musicAudio.clip = musicData.clip;
        musicAudio.volume = musicData.volume;
        musicAudio.Play();
    }

    public void PlaySFX(MusicKey key) {
        
        if (!lastPlayTime.ContainsKey(key))
            lastPlayTime.Add(key, Time.time);
        else {
            if (Time.time - lastPlayTime[key] <= coolDown)
            {
                return;
            }
        }
        lastPlayTime[key] = Time.time;
        MusicData musicData =  musicContainer.GetMusicData(key);
        soundAudio.volume = musicData.volume;
        soundAudio.PlayOneShot(musicData.clip);
    }
}
