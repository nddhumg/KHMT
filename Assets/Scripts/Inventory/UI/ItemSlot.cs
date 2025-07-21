using System.Collections;
using System.Collections.Generic;
using Systems.Inventory;
using TMPro;
using UI.Charector;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Charector
{
    public class ItemSlot : MonoBehaviour, IItemUIUpdater
    {
        [SerializeField] private Image icon;
        [SerializeField] private TMP_Text level;

        [SerializeField] private Button btn;
        private bool isEquiped;

        private static CharectorUIManager manager;

        private IItemData data;
        private IItemLevel levelItem;

        public bool IsEquiped => isEquiped;

        private void Start()
        {
            btn.onClick.AddListener(OpenPopupInfo);
        }

        public static void SetUIManager(CharectorUIManager uiManager)
        {
            manager = uiManager;
        }

        public void Init(IItemData data, IItemLevel levelItem, bool isEquiped)
        {
            if (this.levelItem != null)
            {
                this.levelItem.OnLevelUp -= SetTextLevel;
            }
            this.data = data;
            this.levelItem = levelItem;
            this.levelItem.OnLevelUp += SetTextLevel;
            icon.sprite = data.ModelData.Icon;
            SetTextLevel(levelItem.Level);
            this.isEquiped = isEquiped;
        }

        private void OpenPopupInfo()
        {
            manager.OpenPopupInfoItem(data, this);
        }

        private void SetTextLevel(int levelCurrent) {
            level.text = "Lv " + levelCurrent.ToString();
        }
    }
}
