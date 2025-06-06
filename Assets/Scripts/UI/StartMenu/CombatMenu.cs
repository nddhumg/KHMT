using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatMenu : MonoBehaviour
{
    [SerializeField] protected int combatEnergy = 5;
    [SerializeField] protected Button btnRunGame;

    private void Start()
    {
        btnRunGame.onClick.AddListener(OnClickRunGame);
    }

    public void OnClickRunGame()
    {
        if (ResourceController.instance.GetResource(EnumName.ResourceName.Energy) < combatEnergy)
        {
            return;
        }
        ResourceController.instance.IncreaseResource(EnumName.ResourceName.Energy, -combatEnergy);
        LoadingSceneManager.instance.SwitchToSceneGame("1");
    }
}
