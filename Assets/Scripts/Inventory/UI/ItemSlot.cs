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

        public bool IsEquiped => isEquiped;

        private void Start()
        {
            btn.onClick.AddListener(Click);
        }

        public static void SetUIManager(CharectorUIManager uiManager)
        {
            manager = uiManager;
        }

        public void Init(IItemData data, bool isEquiped)
        {
            this.data = data;
            icon.sprite = data.Model.Icon;
            level.text = "Lv " + data.Level.ToString();
            this.isEquiped = isEquiped;
        }

        private void Click()
        {
            manager.OpenPopupInfoItem(data, this);
        }
    }
}
