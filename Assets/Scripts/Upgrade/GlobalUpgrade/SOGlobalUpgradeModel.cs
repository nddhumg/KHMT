using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/GlobalUpgrade")]
public class SOGlobalUpgradeModel : ScriptableObject, IGlobalUpgradeModel
{
    [SerializeField] private Sprite icon;
    [SerializeField] private GlobalUpgradeLevel[] globalUpgradeLevels;
    [SerializeField] private EnumName.GlobalUpgradeName globalUpgradeName;
    public Sprite Icon => icon;

    public int LevelMax => globalUpgradeLevels.Length;

    public IGlobalUpgradeLevel[] GlobalUpgradeLevels => globalUpgradeLevels;

    public string Name => globalUpgradeName.ToString();

#if UNITY_EDITOR
    private void OnValidate()
    {
        string thisFileNewName = Name;
        string assetPath = UnityEditor.AssetDatabase.GetAssetPath(this.GetInstanceID());
        UnityEditor.AssetDatabase.RenameAsset(assetPath, thisFileNewName);

    }
#endif
}
[System.Serializable]
public class GlobalUpgradeLevel : IGlobalUpgradeLevel
{
    [SerializeField] private string keyMessage;
    [SerializeField] private uint cost;
    public string Description => LocalizationManager.instance.GetMesage(keyMessage);
    public uint Cost => cost;

}
