using TMPro;
using UnityEngine;
using System.Text;
using System;

public class TimePlay : MonoBehaviour
{
    [SerializeField] protected TMP_Text tmpTextTime;


    private void Update()
    {
        tmpTextTime.text = TimeManager.instance.ConvertSecondsToTimeSpan(Time.timeSinceLevelLoad).ToString(@"mm\:ss");
    }

}

