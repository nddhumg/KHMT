using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundClick : MonoBehaviour
{
    private Button btn;

    private void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(SoundPlay);
    }

    private void SoundPlay() {
        MusicManager.instance.PlaySFX(MusicKey.Click);
    }
}
