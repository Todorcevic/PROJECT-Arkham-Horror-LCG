using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using DG.Tweening;
using Sirenix.OdinInspector;
using Arkham.Components;

namespace Arkham.UI
{
    public class ButtonComponent : MonoBehaviour
    {
        private Color simpleTextColor = Color.white;
        private Color hoverTextColor = Color.black;

        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] protected AudioButtonComponent audioButton;
        [SerializeField, Required, ChildGameObjectsOnly] private InteractableComponent interactable;
        [SerializeField, Required, ChildGameObjectsOnly] private Image background;
        [SerializeField, Required, ChildGameObjectsOnly] private TextMeshProUGUI text;

        [Title("CLICK EVENT")]
        [SerializeField] protected UnityEvent clickAction;

        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeHoverAnimation;

        /*******************************************************************/
        private void Start()
        {
            interactable.AddClickAction(ClickEffect);
            interactable.AddHoverOnAction(HoverOnEffect);
            interactable.AddHoverOffAction(HoverOffEffect);
        }

        private void ClickEffect()
        {
            audioButton.ClickSound();
            clickAction?.Invoke();
        }

        private void HoverOnEffect()
        {
            audioButton.HoverOnSound();
            HoverActivate();
        }
        private void HoverOffEffect()
        {
            audioButton.HoverOffSound();
            HoverDesactivate();
        }

        public void HoverActivate()
        {
            ChangeTextColor(hoverTextColor);
            FillBackground(true);
        }

        public void HoverDesactivate()
        {
            ChangeTextColor(simpleTextColor);
            FillBackground(false);
        }

        private void ChangeTextColor(Color color) => text.DOColor(color, timeHoverAnimation);
        private void FillBackground(bool toFill) => background.DOFillAmount(toFill ? 1 : 0, timeHoverAnimation);
    }
}