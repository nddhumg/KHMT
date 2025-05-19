using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Core.Spawn.Enemy;

public class EnemyKillAndCoinUI : MonoBehaviour
{
    [SerializeField] private TMP_Text textCoin;
    [SerializeField] private TMP_Text textEnemyDie;

    private void Update()
    {
        UpdateText();
    }

    void UpdateText()
    {
        //textCoin.text = ;
        textEnemyDie.text = EnemySpawn.instance.EnemyKill.ToString();
    }
}
