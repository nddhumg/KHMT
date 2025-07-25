using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHPBoss : Singleton<UIHPBoss>
{
    [SerializeField] protected Slider sliderHp;
    [SerializeField] protected TMP_Text hpCurrent;
    [SerializeField] protected TMP_Text nameBoss;
    protected Boss boss;

    private void Start()
    {
        gameObject.SetActive(false);
    }
    private void Update()
    {
        float hp = boss.Stat.GetStatValue(Ndd.Stat.StatName.Hp);
        float hpMax = boss.Stat.GetStatValue(Ndd.Stat.StatName.HpMax);

        sliderHp.value = hp / hpMax;
        hpCurrent.text = hp + "/" + hpMax;
    }

    public void Init(Boss boss) {
        this.boss = boss;
        nameBoss.text = boss.NameBoss;
        sliderHp.value = 1;
        gameObject.SetActive(true);
        boss.OnDead += DisableUI;
    }

    void DisableUI() {
        gameObject.SetActive(false);
        boss.OnDead -= DisableUI;
        boss = null;
    }
}
