using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelPlayerText : MonoBehaviour
{
    [SerializeField] protected TMP_Text text;

    private void Update()
    {
        text.text = Player.instance.Level.LevelCurrent.ToString();
    }
}
