using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Systems.SaveLoad;
public class TutorialControl : PersistentSingleton<TutorialControl>
{
    [SerializeField,ReadOnly]TutorialData data = new TutorialData();

    public bool IsFirstInGame => data.isFirstInGame;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        data = SaveLoadSystem.DataService.Load<TutorialData>(gameObject) ?? data;
    }

    private void OnApplicationQuit()
    {
        data.isFirstInGame = false;
        SaveLoadSystem.DataService.Save<TutorialData>(ref data);
    }
}
