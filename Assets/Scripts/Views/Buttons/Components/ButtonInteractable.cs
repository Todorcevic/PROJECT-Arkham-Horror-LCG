using Arkham.Controllers;
using DG.Tweening;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Arkham.Views
{
    public class ButtonInteractable : InteractableComponent
    {
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private InteractableAudio interactableAudio;
        [SerializeField, Required, ChildGameObjectsOnly] private Image background;
        [SerializeField, Required, ChildGameObjectsOnly] private TextMeshProUGUI text;
        [SerializeField, ChildGameObjectsOnly] private TextMeshProUGUI secundaryText;
        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeHoverAnimation;
        [Title("CLICK EVENT")]
        [SerializeField] protected UnityEvent clickAction;

        /*******************************************************************/
        public override void ClickEffect()
        {
            interactableAudio.ClickSound();
            clickAction?.Invoke();
        }

        public override void DoubleClickEffect() => ClickEffect();

        public override void HoverOnEffect()
        {
            interactableAudio.HoverOnSound();
            HoverActivate();
        }

        public override void HoverOffEffect()
        {
            interactableAudio.HoverOffSound();
            HoverDesactivate();
        }

        public void HoverActivate()
        {
            ChangeTextColor(Color.black);
            FillBackground(true);
        }

        public void HoverDesactivate()
        {
            ChangeTextColor(Color.white);
            FillBackground(false);
        }

        private void ChangeTextColor(Color color)
        {
            text.DOColor(color, timeHoverAnimation);
            secundaryText?.DOColor(color, timeHoverAnimation);
        }

        private void FillBackground(bool toFill) => background.DOFillAmount(toFill ? 1 : 0, timeHoverAnimation);
    }
}