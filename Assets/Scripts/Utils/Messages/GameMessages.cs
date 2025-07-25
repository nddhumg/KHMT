using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName ="SO/Manager/GameMessages", fileName ="GameMessage")]
public class GameMessages : ScriptableObject
{
    [SerializeField]  List<MessageEntry> messages = new();
    private static Dictionary<MessageKey, MessageEntry> dictionaryMessages;
    [SerializeField] protected static LanguageKey language = LanguageKey.Vi;

    public List<MessageEntry> Messages => messages;

#if UNITY_EDITOR
    [Button]
    protected void GetData()
    {
        messages.Clear();
        foreach (var data in CsvCollectionManager.Container.GameMessagesSheet)
        {
            MessageEntry entry = new MessageEntry() { key = data.Id, vi = data.Vi, eng = data.Eng };
            messages.Add(entry);
        }
        EditorUtility.SetDirty(this);
        AssetDatabase.SaveAssets();
    }

#endif

}
[Serializable]
public class MessageEntry
{
    public string key;
    public string vi;
    public string eng;
}
public enum MessageKey
{
    NotEnoughGold,
    NotEnoughDia,
    NotAvailable,
    NotEnoughEnergy,
}

public enum LanguageKey
{
    Vi, Eng,
}
