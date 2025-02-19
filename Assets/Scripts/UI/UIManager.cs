using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] protected GameObject pauseBtn;
    [SerializeField] protected GameObject menu;
    [SerializeField] protected Slider sliderMusic;
    [SerializeField] protected Slider sliderVolumn;
    [SerializeField] protected Text textCoinChest;


    private void Start()
    {
        pauseBtn.SetActive(true);
        menu.SetActive(false);
    }

    public void ClickPause(bool isPause) {
            pauseBtn.SetActive(!isPause);
            menu.SetActive(isPause);
        if(isPause ) 
            GameSystem.Pause();
        else
            GameSystem.RePause();
    }

    public void ChangeMusic() {
        //sliderMusic.value;
    }

    public void ClickMusic() { 
    
    }

    public void ChangeVolume(){
        //sliderVolumn.value
    }
    public void ClickVolume()
    {

    }
}
