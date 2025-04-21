using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenMenuGame : Singleton<ScreenMenuGame>
{
    [SerializeField] protected Button btnOpenMenu;

    [Header("Music")]
    [SerializeField] protected Button btnMusic;
    [SerializeField] protected Button btnSound;
    [SerializeField] protected Image imageMusic;
    [SerializeField] protected Image imageSound;

    [SerializeField] protected Sprite iconMusic;
    [SerializeField] protected Sprite iconMusicMute;
    [SerializeField] protected Sprite iconSound;
    [SerializeField] protected Sprite iconSoundMute;

    [SerializeField] protected Button btnGoHome;
    [SerializeField] protected Button btnContinue;

    [SerializeField] protected GameObject popupGoHome;

    protected bool isMuteMusic;
    protected bool isMuteSound;


    private void Start()
    {
        btnOpenMenu.gameObject.SetActive(true);
        SetUpBtn();
        UpdateImageMusicMute();
        UpdateImageSoundMute();
    }

    public void OpenMenu(bool isOpen)
    {
        gameObject.SetActive(isOpen);
        if (isOpen)
            GameSystem.Pause();
        else
            GameSystem.RePause();
    }

    public void ClickMuteMusic()
    {
        MusicManager.instance.ChangeMuteMusic();
        UpdateImageMusicMute();
    }

    public void ClickMuteSound()
    {
        MusicManager.instance.ChangeMuteSound();
        UpdateImageSoundMute();
    }

    protected void UpdateImageMusicMute()
    {
        if (MusicManager.instance.IsMuteMusic)
        {
            imageMusic.sprite = iconMusicMute;
        }
        else
        {
            imageMusic.sprite = iconMusic;
        }
    }
    protected void UpdateImageSoundMute()
    {
        if (MusicManager.instance.IsMuteSound)
        {
            imageSound.sprite = iconSoundMute;
        }
        else
        {
            imageSound.sprite = iconSound;
        }
    }

    private void SetUpBtn()
    {
        btnOpenMenu.onClick.AddListener(() => OpenMenu(true));
        btnMusic.onClick.AddListener(ClickMuteMusic);
        btnSound.onClick.AddListener(ClickMuteSound);
        btnContinue.onClick.AddListener(() => OpenMenu(false));
        btnGoHome.onClick.AddListener(() => popupGoHome.SetActive(true));
    }

}
