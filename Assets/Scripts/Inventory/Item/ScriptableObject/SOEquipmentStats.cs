using EnumName;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Systems.Inventory {
    [CreateAssetMenu(menuName = "SO/Inventory/EquipmentStats" , fileName = "EquipmentStats")]
    public class SOEquipmentStats : ScriptableObject
    {
        [ArrayElementTitle("type")]
        [SerializeField] private List<EquipmentStats> equipmentStats;

        public IEquipmentStats GetEquipmentStats(EnumName.EquipmentType type) {
            return equipmentStats.Find(stat => stat.Type == type);
        }

    }
    [System.Serializable]
    public class EquipmentStats : IEquipmentStats
    {

        [SerializeField] private EnumName.EquipmentType type;
        [SerializeField] private EnumName.Stat statBonus;
        [SerializeField] private List<float> bonus;
        [SerializeField] private List<float> bonusLevelUp;
        [SerializeField] private Sprite iconType;
        [SerializeField] private Sprite iconStat;

        public EnumName.EquipmentType Type => type;

        public Sprite IconType => iconType;

        public Sprite IconStat => iconStat;

        public Stat StatBonus => statBonus;

        public float GetBonus(int rarity)
        {
            return bonus[rarity];
        }

        public float GetBonusLevelUp(int rarity)
        {
            return bonusLevelUp[rarity];
        }
    }
}
