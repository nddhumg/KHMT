using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UIStart
{
    public class FeatureMenu : MonoBehaviour
    {
        public enum Feature
        {
            Combat,
            Shop,
            Charector,
        }

        protected Feature featureCurrent ;
        [Header("UI")]
        [SerializeField] private GameObject uiCombat;
        [SerializeField] private GameObject uiShop;
        [SerializeField] private GameObject uiCharector;

        [Header("Button")]
        [SerializeField] private Button buttonCombat;
        [SerializeField] protected Button buttonShop;
        [SerializeField] protected Button buttonCharector;

        private void Start()
        {
            buttonCharector.onClick.AddListener(() => ChangeFeature(Feature.Charector));
            buttonCombat.onClick.AddListener(() => ChangeFeature(Feature.Combat));
            buttonShop.onClick.AddListener(() => ChangeFeature(Feature.Shop));
            uiCombat.SetActive(true);
            featureCurrent = Feature.Combat;
        }

        public void ChangeFeature(Feature feature)
        {
            if (feature == featureCurrent)
                return;
            SetActiveUIFeature(featureCurrent,false);
            SetActiveUIFeature(feature, true);
            featureCurrent = feature;  
        }

        protected void SetActiveUIFeature(Feature feature,bool isActive)
        {
            switch (feature)
            {
                case Feature.Combat:
                    uiCombat.SetActive(isActive);
                    break;
                case Feature.Shop:
                    uiShop.SetActive(isActive);
                    break;
                case Feature.Charector:
                    uiCharector.SetActive(isActive);
                    break;

            }
        }

    }
}
