using Ndd.Cooldown;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class PopupDamage : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    private ICoolDownAuto timer;
    [SerializeField] private float coolDownDestroy = 0.5f;
    [SerializeField] private float bounceHeight = 0.2f;

    private void Start()
    {
        timer = new AutoCooldownTimer(coolDownDestroy,action:() => gameObject.SetActive(false));
    }

    private void Update()
    {
        timer.UpdateCooldown(Time.deltaTime);
    }

    private void OnEnable()
    {
        transform.DOPunchPosition(Vector3.up * bounceHeight, coolDownDestroy, 1, 0);

    }

    public void SetText(string value) { 
        text.text = value;
    }

    public void SetText(float value)
    {
        text.text = value.ToString();
    }
}
