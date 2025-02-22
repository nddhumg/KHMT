using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatMenu : MonoBehaviour
{
    public void OnClickRunGame() {
        LoadingSceneManager.instance.SwitchToSceneGame("game");
    }
}
