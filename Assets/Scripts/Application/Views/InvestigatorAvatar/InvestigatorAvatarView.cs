using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Arkham.Application
{
    public class InvestigatorAvatarView : MonoBehaviour
    {
        [Title("RESOURCES")]
        [SerializeField, Required] private CanvasGroup canvasGroup;
        [SerializeField, Required] private Image image;
        [SerializeField, Required, ChildGameObjectsOnly] private InvestigatorToken physicTrauma;
        [SerializeField, Required, ChildGameObjectsOnly] private InvestigatorToken mentalTrauma;
        [SerializeField, Required, ChildGameObjectsOnly] private InvestigatorToken xp;

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
        public void SetXp(int amount) => xp.UpdateAmount(amount);
    }
}
