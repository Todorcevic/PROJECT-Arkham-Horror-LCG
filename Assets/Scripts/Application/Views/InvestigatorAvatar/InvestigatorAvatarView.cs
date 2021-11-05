using Arkham.Config;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Arkham.Application
{
    public class InvestigatorAvatarView : MonoBehaviour
    {
        [Title("RESOURCES")]
        [SerializeField, Required] private CanvasGroup canvasGroup;
        [SerializeField, Required] private Image image;
        [SerializeField, Required, ChildGameObjectsOnly] private TokenView physicTrauma;
        [SerializeField, Required, ChildGameObjectsOnly] private TokenView mentalTrauma;
        [SerializeField, Required, ChildGameObjectsOnly] private TokenView xp;
        [SerializeField] private ButtonIcon physicTraumaButton;
        [SerializeField] private ButtonIcon mentalTraumaButton;

        /*******************************************************************/
        public void SetAvatar(Sprite sprite, int physicAmount, int mentalAmount, int xpAmount)
        {
            ChangeImage(sprite);
            SetPhysicTrauma(physicAmount);
            SetMentalTrauma(mentalAmount);
            SetXp(xpAmount);
        }

        private void ChangeImage(Sprite sprite)
        {
            bool isActive = sprite != null;
            canvasGroup.alpha = isActive ? 1 : 0;
            canvasGroup.blocksRaycasts = canvasGroup.interactable = isActive;
            image.sprite = sprite;
        }

        public void SetPhysicTrauma(int amount) => physicTrauma.UpdateAmount(amount);

        public void SetMentalTrauma(int amount) => mentalTrauma.UpdateAmount(amount);

        public void SetXp(int amount)
        {
            xp.UpdateAmount(amount);
            CheckActiveTraumas(amount);
        }

        private void CheckActiveTraumas(int xpAmount)
        {
            bool isInactive = xpAmount < GameValues.TRAUMA_COST;
            physicTraumaButton.IsInactive(isInactive);
            mentalTraumaButton.IsInactive(isInactive);
        }
    }
}
