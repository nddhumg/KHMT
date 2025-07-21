using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CombatMenu : MonoBehaviour
{
    [SerializeField] protected int combatEnergy = 5;
    [SerializeField] protected Button btnRunGame;

    [SerializeField] protected TMP_Text textNameMap;
    protected string textDefaultMap = "Map 1";
    [SerializeField] protected int idMapDefault = 1;
    [SerializeField] protected int idMapCurrent = 1;
    [SerializeField] protected int idMapMax = 2;

    [SerializeField] protected Button btnRightMap;
    [SerializeField] protected Button btnLeftMap;

    private void Start()
    {
        btnRunGame.onClick.AddListener(OnClickRunGame);
        textNameMap.text = textDefaultMap;
        btnRightMap.onClick.AddListener(() => ChangeMapId(true));
        btnLeftMap.onClick.AddListener(() => ChangeMapId(false));
    }

    public void OnClickRunGame()
    {
        if (ResourceController.instance.GetResource(EnumName.ResourceName.Energy) < combatEnergy)
        {
            return;
        }
        ResourceController.instance.IncreaseResource(EnumName.ResourceName.Energy, -combatEnergy);
        LoadingSceneManager.instance.SwitchToSceneGame(idMapCurrent.ToString());
    }

    protected void ChangeMapId(bool isIncrement)
    {
        int idMapLast = idMapCurrent;
        if (isIncrement)
        {
            idMapCurrent++;
        }
        else {
            idMapCurrent--;
        }
        if (idMapCurrent == 0 || idMapCurrent == idMapMax + 1) {
            idMapCurrent = idMapLast;
            StartSceenManager.instance.OpenPopupDebug(GameMessages.GetMesage(MessageKey.NotAvailable));
            return;
        }
        textNameMap.text = "Map " + idMapCurrent;
    }

}
