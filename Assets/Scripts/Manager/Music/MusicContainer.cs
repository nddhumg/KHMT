using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MusicContainer : MonoBehaviour
{
    [SerializeField] private List<MusicData> musicData;
    [SerializeField] private List<MusicData> sfxData;
    private Dictionary<MusicKey, MusicData> dictionaryMusic;


    private void Awake()
    {
        dictionaryMusic = new();
        musicData.ForEach(data => dictionaryMusic.Add(data.key, data));
        sfxData.ForEach(data => dictionaryMusic.Add(data.key, data));
    }
    public MusicData GetMusicData(MusicKey key) { 
        return dictionaryMusic[key];
    }
}
