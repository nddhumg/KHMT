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
    [SerializeField] protected Button btnReplay;
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
        btnContinue.onClick.AddListener(OnClickContinue);
        btnReplay.onClick.AddListener(OnClickReplay);
        SetUpButton();
        Player.instance.OnPlayerDead += Deffeat;
    }



    public void Victory()
    {
        GameSystem.Pause();
        textGameOver.text = LocalizationManager.instance.GetMesage("Victory");
        bg.color = colorVictory;
        btnContinue.gameObject.SetActive(true);
        btnReplay.gameObject.SetActive(false);
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

    public void ShowUIDeffeat()
    {
        GameSystem.Pause();
        textGameOver.text = LocalizationManager.instance.GetMesage("Deffeat");
        bg.color = colorDeffeat;
        btnReplay.gameObject.SetActive(true);
        btnContinue.gameObject.SetActive(false);
        UpdateInfo();
    }

    protected void OnClickContinue()
    {
        //LoadingSceneManager.instance.
    }

    protected void OnClickHome()
    {
        LoadingSceneManager.instance.SwitchToSceneStartGame();
        GameSystem.RePause();
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
