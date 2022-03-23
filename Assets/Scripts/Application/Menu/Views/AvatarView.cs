using Arkham.Model;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Arkham.Application.MainMenu
{
    public class AvatarView : MonoBehaviour
    {
        [Title("RESOURCES")]
        [SerializeField, Required] private CanvasGroup canvasGroup;
        [SerializeField, Required] private Image image;
        [SerializeField, Required] private TokenView physicTrauma;
        [SerializeField, Required] private TokenView mentalTrauma;
        [SerializeField, Required] private TokenView xp;
        [SerializeField] private ButtonIconView physicTraumaButton;
        [SerializeField] private ButtonIconView mentalTraumaButton;

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

        private void SetPhysicTrauma(int amount) => physicTrauma.UpdateAmount(amount);

        private void SetMentalTrauma(int amount) => mentalTrauma.UpdateAmount(amount);

        private void SetXp(int amount)
        {
            xp.UpdateAmount(amount);
            CheckActiveTraumas(amount);
        }

        private void CheckActiveTraumas(int xpAmount)
        {
            bool isInactive = xpAmount < GameValues.TRAUMA_COST;
            physicTraumaButton.Desactive(isInactive);
            mentalTraumaButton.Desactive(isInactive);
        }
    }
}
