using Arkham.Managers;
using DG.Tweening;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Arkham.Views
{
    public class ButtonEffects : MonoBehaviour, IInteractableEffects
    {
        [Title("RESOURCES")]
        [SerializeField] private ButtonsManager manager;
        [SerializeField, Required, ChildGameObjectsOnly] private InteractableAudio interactableAudio;
        [SerializeField, Required, ChildGameObjectsOnly] private Image background;
        [SerializeField, Required, ChildGameObjectsOnly] private TextMeshProUGUI text;
        [SerializeField, ChildGameObjectsOnly] private TextMeshProUGUI secundaryText;
        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeHoverAnimation;
        [Title("CLICK EVENT")]
        [SerializeField] private UnityEvent clickAction;

        /*******************************************************************/

        public void ClickEffect()
        {
            if (manager?.CurrentButton == this) return;
            manager?.SelectTab(this);
            interactableAudio.ClickSound();
            clickAction?.Invoke();
        }

        public void DoubleClickEffect() { }

        public void HoverOnEffect()
        {
            if (manager?.CurrentButton == this) return;
            interactableAudio.HoverOnSound();
            HoverActivate();
        }

        public void HoverOffEffect()
        {
            if (manager?.CurrentButton == this) return;
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