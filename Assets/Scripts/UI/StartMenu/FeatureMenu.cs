using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using static System.TimeZoneInfo;

namespace UIManager.UIStartSceen
{
    public class FeatureMenu : MonoBehaviour
    {
        public enum Feature
        {
            Shop, Upgrade, Combat, Charector, BattlePass,
        }

        protected Feature featureCurrent;

        [Header("UI")]
        [SerializeField] private RectTransform uiCombat;
        [SerializeField] private RectTransform uiShop;
        [SerializeField] private RectTransform uiCharector;
        [SerializeField] private RectTransform uiBattlePass;
        [SerializeField] private RectTransform uiUpgrade;

        [Header("Button")]
        [SerializeField] private Button buttonCombat;
        [SerializeField] private Button buttonShop;
        [SerializeField] private Button buttonCharector;
        [SerializeField] private Button buttonBattlePass;
        [SerializeField] private Button buttonUpgrade;


        private void Start()
        {
            SetUpButton();
            SetUpStartMenu();
        }

        public void ChangeFeature(Feature feature)
        {
            if (feature == featureCurrent)
                return;
            SetActiveUIFeature(featureCurrent, false);
            SetActiveUIFeature(feature, true);
            //AnimationChangeFeature(feature);
            featureCurrent = feature;
        }

        protected void SetUpButton()
        {
            buttonCharector.onClick.AddListener(() => ChangeFeature(Feature.Charector));
            buttonCombat.onClick.AddListener(() => ChangeFeature(Feature.Combat));
            buttonShop.onClick.AddListener(() => ChangeFeature(Feature.Shop));
            //buttonBattlePass.onClick.AddListener(() => ChangeFeature(Feature.BattlePass));
            //buttonUpgrade.onClick.AddListener(() => ChangeFeature(Feature.Upgrade));
            buttonBattlePass.onClick.AddListener(() => StartSceenManager.instance.OpenPopupInDevelopment());
            buttonUpgrade.onClick.AddListener(() => StartSceenManager.instance.OpenPopupInDevelopment());
        }

        protected void SetUpStartMenu()
        {
            uiCombat.gameObject.SetActive(true);
            featureCurrent = Feature.Combat;
        }

        //protected void AnimationChangeFeature(Feature featureNew)
        //{
        //    int directionMoveFeatureCurrent = (int)featureCurrent > (int)featureNew ? 1 : -1;
        //    RectTransform uiCurrent = GetUIFeature(featureCurrent);
        //    RectTransform uiNew = GetUIFeature(featureNew);

        //    float screenWidth = uiCurrent.rect.width;

        //    uiNew.gameObject.SetActive(true);
        //    uiCurrent.DOAnchorPos(new Vector2(directionMoveFeatureCurrent * screenWidth, 0), .3f)
        //        .SetEase(Ease.InOutQuad)
        //        .OnComplete(() => uiCurrent.gameObject.SetActive(false));

        //    uiNew.anchoredPosition = new Vector2(-directionMoveFeatureCurrent * screenWidth, 0);
        //    uiNew.DOAnchorPos(Vector2.zero, .3f).SetEase(Ease.InOutQuad);
        //}

        protected void SetActiveUIFeature(Feature feature, bool isActive)
        {
            switch (feature)
            {
                case Feature.Combat:
                    uiCombat.gameObject.SetActive(isActive);
                    break;
                case Feature.Shop:
                    uiShop.gameObject.SetActive(isActive);
                    break;
                case Feature.Charector:
                    uiCharector.gameObject.SetActive(isActive);
                    break;
                case Feature.BattlePass:
                    uiBattlePass.gameObject.SetActive(isActive);
                    break;
                case Feature.Upgrade:
                    uiUpgrade.gameObject.SetActive(isActive);
                    break;
            }
        }

    }
}
