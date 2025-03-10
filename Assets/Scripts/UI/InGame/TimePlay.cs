using TMPro;
using UnityEngine;
using System.Text;
using System;

public class TimePlay : Singleton<TimePlay>
{
    [SerializeField] protected TMP_Text tmpTextTime;
    protected string textTime;
    private float lastTime = -1f;

    public string TextTime => textTime;

    private void Update()
    {
        UpdateTextTime();
    }

    private void UpdateTextTime()
    {
        float secondBase = Time.timeSinceLevelLoad;
        int minutes = (int)(secondBase / 60);
        int seconds = (int)(secondBase % 60);

        if (seconds + minutes * 60 != (int)lastTime)
        {
            lastTime = seconds + minutes * 60;
            textTime = $"{minutes:00} : {seconds:00}";
            tmpTextTime.text = textTime;
        }
    }
}

