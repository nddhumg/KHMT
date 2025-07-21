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

    protected void OnEnable()
    {
        dictionaryMessages = new Dictionary<MessageKey, MessageEntry>();
        messages.ForEach(message => dictionaryMessages.Add(message.key, message));
    }
    public static string GetMesage(MessageKey messageKey)
    {
        MessageEntry message = dictionaryMessages[messageKey];
        if (message == null)
            return string.Empty;
        switch (language)
        {
            case LanguageKey.Vi:
                return message.vi;
            case LanguageKey.Eng:
                return message.eng;
            default:
                return string.Empty;
        }
    }

}
[Serializable]
public class MessageEntry
{
    public MessageKey key;
    public string vi;
    public string eng;
}
public enum MessageKey
{
    NotEnoughGold,
    NotEnoughDia,
    NotAvailable,
}

public enum LanguageKey
{
    Vi, Eng,
}
