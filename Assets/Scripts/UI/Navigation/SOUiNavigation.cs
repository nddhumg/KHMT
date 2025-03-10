using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName ="SO/UI/N")]
public abstract class SOUiNavigation : ScriptableObject
{

    public abstract void StartAnimationUi(GameObject ui);
    public abstract void EndNavigationUi(GameObject ui);
    
}
