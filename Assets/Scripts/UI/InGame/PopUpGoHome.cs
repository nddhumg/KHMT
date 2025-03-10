using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpGoHome : MonoBehaviour
{
    [SerializeField] protected Button btnYes;
    [SerializeField] protected Button btnNo;
    [SerializeField] protected ScreenMenuGame menuGame;


    private void Start()
    {
        btnYes.onClick.AddListener(ClickYes);
        btnNo.onClick.AddListener(() => gameObject.SetActive(false));
    }

    private void ClickYes()
    {
        ScreenGameOver.instance.Deffeat();
        menuGame.OpenMenu(false);
        gameObject.SetActive(false);
    }


}
