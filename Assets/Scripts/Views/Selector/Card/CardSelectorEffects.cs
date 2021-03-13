using DG.Tweening;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Arkham.Views
{
    public class CardSelectorEffects : MonoBehaviour
    {
        [Title("RESOURCES")]
        [SerializeField, Required] private InteractableAudio interactableAudio;
        [SerializeField, Required, ChildGameObjectsOnly] private Image background;
        [SerializeField, Required, ChildGameObjectsOnly] private TextMeshProUGUI cardName;
        [SerializeField, ChildGameObjectsOnly] private TextMeshProUGUI quantity;
        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeHoverAnimation;

        /*******************************************************************/
        public void ClickEffect() => interactableAudio.ClickSound();

        public void HoverOnEffect()
        {
            interactableAudio.HoverOnSound();
            HoverActivate();
        }

        public void HoverOffEffect()
        {
            interactableAudio.HoverOffSound();
            HoverDesactivate();
        }

        private void HoverActivate()
        {
            ChangeTextColor(Color.black);
            FillBackground(true);
        }

        private void HoverDesactivate()
        {
            ChangeTextColor(Color.white);
            FillBackground(false);
        }

        private void ChangeTextColor(Color color)
        {
            cardName.DOColor(color, timeHoverAnimation);
            quantity?.DOColor(color, timeHoverAnimation);
        }

        private void FillBackground(bool toFill) => background.DOFillAmount(toFill ? 1 : 0, timeHoverAnimation);
    }
}
