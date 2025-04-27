using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScreenGameOver : Singleton<ScreenGameOver>
{
    [SerializeField] protected GameObject main;
    [SerializeField] protected Image bg;
    [SerializeField] protected TMP_Text textGameOver;
    [SerializeField] protected Button btnHome;
    [SerializeField] protected Button btnContinue;
    [SerializeField] protected TMP_Text textBtnContinue;
    [SerializeField] protected TMP_Text textEnemyDie;
    [SerializeField] protected TMP_Text textTime;


    private void Start()
    {
        main.SetActive(false);
        SetUpButton();
    }

    public void Victory()
    {
        GameSystem.Pause();
        textGameOver.text = "VICTORY";
        btnContinue.onClick.AddListener(OnClickContinue);
        textBtnContinue.text = "Continue";
        UpdateInfo();
    }

    public void Deffeat()
    {
        GameSystem.Pause();
        textGameOver.text = "DEFFEAT";
        btnContinue.onClick.AddListener(OnClickReplay);
        textBtnContinue.text = "Replay";
        UpdateInfo();
    }

    protected void OnClickContinue()
    {

    }

    protected void OnClickHome()
    {
        GameSystem.RePause();
        LoadingSceneManager.instance.SwichToScene("StartSceen");
    }


    protected void OnClickReplay()
    {
        GameSystem.Pause();
        LoadingSceneManager.instance.SwitchToSceneGame("game");
    }
    protected void UpdateInfo()
    {
        main.SetActive(true);
        textEnemyDie.text = EnemySpawn.instance.EnemyKill.ToString();
        textTime.text = TimePlay.instance.TextTime;
    }

    protected void SetUpButton() {
        btnHome.onClick.AddListener(OnClickHome);
    }
}
