using AYellowpaper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinManager : Singleton<WinManager>
{
    protected List<IWinCondition> anyWinConditions = new List<IWinCondition>();
    protected List<IWinCondition> allWinConditions = new List<IWinCondition>();
    protected bool isWin = false;

    public enum WinConditionGroupType
    {
        Any, All,
    }

    private void Update()
    {
        if (isWin)
            return;
        foreach (var condition in anyWinConditions)
        {
            if (condition.IsSatisfied())
            {
                isWin = true;
                OnWin();
                return;
            }
        }

        foreach (var condition in allWinConditions)
        {
            if (condition.IsSatisfied())
            {
                isWin = true;
            }
            else
            {
                isWin = false;
            }
        }
        if (isWin)
            OnWin();
    }
    public void AddWinCondition(IWinCondition condition, WinConditionGroupType type)
    {
        if (condition == null)
            return;
        if (type == WinConditionGroupType.Any)
        {
            anyWinConditions.Add(condition);
        }
        else if (type == WinConditionGroupType.All)
        {
            allWinConditions.Add(condition);
        }
    }

    public void AddWinCondition(IWinConditionData conditionData, WinConditionGroupType type)
    {
        AddWinCondition(conditionData.GetCondition(), type);
    }

    public void AddWinCondition(List<InterfaceReference<IWinConditionData>> conditionsData, WinConditionGroupType type) {
        foreach (var conditionData in conditionsData) {
            AddWinCondition(conditionData.Value.GetCondition(), type);
        }
    }

    protected void OnWin()
    {
        ScreenGameOver.instance.Victory();
    }
}
