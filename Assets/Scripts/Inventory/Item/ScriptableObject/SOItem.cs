
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using EnumName;
using System;

namespace Systems.Inventory
{
    [CreateAssetMenu(menuName = "SO/Item/Appare")]
    public abstract class SOItem : ScriptableObject, IItemModel 
    {
        [SerializeField] protected Sprite icon;
        [ReadOnly, SerializeField] protected EquipmentType equipmentType;
        [SerializeField] protected int levelMax = 100;

        public SOItem(EquipmentType type)
        {
            this.equipmentType = type;
        }

        public abstract string NameItem { get; }

        public EquipmentType Type => equipmentType;

        public Sprite Icon => icon;

        public int LevelMax => levelMax;
        private void OnValidate()
        {
            string thisFileNewName = NameItem;
            string assetPath = UnityEditor.AssetDatabase.GetAssetPath(this.GetInstanceID());
            UnityEditor.AssetDatabase.RenameAsset(assetPath, thisFileNewName);

        }
    }
}
