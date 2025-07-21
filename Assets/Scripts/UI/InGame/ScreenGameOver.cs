using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Core.Spawn.Enemy;
using System.Threading.Tasks;

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

    [SerializeField] protected Color colorVictory;
    [SerializeField] protected Color colorDeffeat;

    [SerializeField] protected PopupRevive popupRevive;
    protected bool canRevive = true;


    private void Start()
    {
        main.SetActive(false);
        popupRevive.gameObject.SetActive(false);
        SetUpButton();
        Player.instance.OnPlayerDead += Deffeat;
    }



    public void Victory()
    {
        GameSystem.Pause();
        textGameOver.text = "VICTORY";
        bg.color = colorVictory;
        btnContinue.onClick.AddListener(OnClickContinue);
        textBtnContinue.text = "Continue";
        UpdateInfo();
    }

    [Button]
    public void Deffeat()
    {
        GameSystem.Pause();
        if (canRevive)
        {
            canRevive = false;
            popupRevive.Show();
        }
        else
        {
            ShowUIDeffeat();
        }
    }

    public void ShowUIDeffeat() {
        GameSystem.Pause();
        textGameOver.text = "DEFFEAT";
        bg.color = colorDeffeat;
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
        GameSystem.RePause();
        LoadingSceneManager.instance.SwitchToSceneGame(GameController.instance.MapId);
    }
    protected void UpdateInfo()
    {
        main.SetActive(true);
        textEnemyDie.text = EnemySpawn.instance.EnemyKill.ToString();
        textTime.text = TimeManager.instance.ConvertSecondsToTimeSpan(Time.timeSinceLevelLoad).ToString(@"mm\:ss");
    }

    protected void SetUpButton()
    {
        btnHome.onClick.AddListener(OnClickHome);
    }
}
