using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextLocalizer : MonoBehaviour
{
    protected Text text;
    protected TMP_Text tmpText;
    [SerializeField] private string messageKey;

    private void Start()
    {
        if (TryGetComponent<Text>(out text))
        {
            text.text = LocalizationManager.instance.GetMesage(messageKey);
        }
        if (TryGetComponent<TMP_Text>(out tmpText))
        {
            tmpText.text = LocalizationManager.instance.GetMesage(messageKey);
        }
    }
}
