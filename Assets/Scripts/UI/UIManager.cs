using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] protected GameObject pauseBtn;
    [SerializeField] protected GameObject menu;

    [Header("Music")]
    [SerializeField] protected Slider sliderMusic;
    [SerializeField] protected Slider sliderSound;
    [SerializeField] protected Button btnMusic;
    [SerializeField] protected Button btnSound;
    [SerializeField] protected Sprite[] iconMusic;
    [SerializeField] protected Sprite[] iconSound;
    //[SerializeField] protected Text textCoinChest;

    protected bool isMuteMusic;
    protected bool isMuteSound;


    private void Start()
    {
        pauseBtn.SetActive(true);
        menu.SetActive(false);
        sliderMusic.onValueChanged.AddListener(MusicManager.instance.ChangeVolumnMusic);
        sliderSound.onValueChanged.AddListener(MusicManager.instance.ChangeVolumnSound);
        btnMusic.onClick.AddListener(MusicManager.instance.ChangeMuteMusic);
        btnMusic.onClick.AddListener(MusicManager.instance.ChangeMuteSound);

    }

    public void ClickPause(bool isPause) {
            pauseBtn.SetActive(!isPause);
            menu.SetActive(isPause);
        if(isPause ) 
            GameSystem.Pause();
        else
            GameSystem.RePause();
    }

    public void ClickMuteMusic()
    {
        MusicManager.instance.ChangeMuteMusic();
        if (MusicManager.instance.IsMuteMusic)
        {

        }
    }

    public void ClickMuteSound() {
        MusicManager.instance.ChangeMuteSound();
    }
}
