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
    private float volumeMusic,volumeSFX;
    private Dictionary<MusicKey, float> lastPlayTime = new();
    private float coolDown = 0.3f;

    public float VolumeMusic => musicAudio.volume;
    public float VolumeSound => soundAudio.volume;
    public bool IsMuteMusic => musicAudio.mute;
    public bool IsMuteSound => soundAudio.mute;

    protected void Start()
    {
        volumeMusic = 1;
        volumeSFX = 1;
        musicAudio.volume = volumeMusic;
        soundAudio.volume = volumeSFX;
    }

    public void PlayMusic(MusicData data)
    {
        if (musicAudio.clip == null)
        {
            musicAudio.clip = data.clip;
            musicAudio.volume = data.volume * volumeMusic;
            musicAudio.Play();
        }
        else
        {
            StartCoroutine(SwitchMusic(data));
        }
    }

    public void PlayMusic(MusicKey key)
    {
        MusicData musicData = musicContainer.GetMusicData(key);
        PlayMusic(musicData);
    }

    public void PlaySFX(MusicKey key)
    {

        if (!lastPlayTime.ContainsKey(key))
            lastPlayTime.Add(key, Time.time);
        else
        {
            if (Time.time - lastPlayTime[key] <= coolDown)
            {
                return;
            }
        }
        lastPlayTime[key] = Time.time;
        MusicData musicData = musicContainer.GetMusicData(key);
        soundAudio.volume = volumeSFX * musicData.volume;
        soundAudio.PlayOneShot(musicData.clip);
    }

    public void ChangeVolumnMusic(float value) {
        musicAudio.volume = value;
        volumeMusic = value;
    }

    public void ChangeVolumnSound(float value) { 
        soundAudio.volume = value;
        volumeSFX = value;
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
        for (float t = 0; t <= fadeDuration/2; t += Time.unscaledDeltaTime)
        {
            musicAudio.volume = Mathf.SmoothStep(startVolume, 0, t / (fadeDuration / 2));
            yield return null;
        }

        musicAudio.volume = 0;

        musicAudio.clip = data.clip;
        musicAudio.Play();

        for (float t = 0; t <= fadeDuration/2; t += Time.unscaledDeltaTime)
        {
            musicAudio.volume = Mathf.SmoothStep(0, data.volume * volumeMusic, t / (fadeDuration / 2));
            yield return null;
        }

        musicAudio.volume = data.volume * volumeMusic ;
    }

   
}
