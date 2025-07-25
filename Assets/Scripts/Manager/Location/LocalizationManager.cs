using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationManager : PersistentSingleton<LocalizationManager>
{
    [SerializeField] protected GameMessages gameMessages;
    private Dictionary<string, MessageEntry> dictionaryMessages;
    [SerializeField] protected LanguageKey language = LanguageKey.Vi;

    protected override void Awake()
    {
        base.Awake();
        dictionaryMessages = new Dictionary<string, MessageEntry>();
        gameMessages.Messages.ForEach(message => dictionaryMessages.Add(message.key, message));
    }

    public string GetMesage(MessageKey messageKey) {
        return GetMesage(messageKey.ToString());
    }

    public string GetMesage(string messageKey)
    {
        MessageEntry message;
        try
        {
            message = dictionaryMessages[messageKey];
        }
        catch {
            Debug.Log("Not key " + messageKey);
            return string.Empty;
        }
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
