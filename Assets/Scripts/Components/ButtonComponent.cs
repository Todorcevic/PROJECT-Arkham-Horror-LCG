using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using DG.Tweening;
using Sirenix.OdinInspector;
using Arkham.Components;
using Arkham.Views;
using System.Collections.Generic;

namespace Arkham.UI
{
    public class ButtonComponent : MonoBehaviour
    {
        private Color simpleTextColor = Color.white;
        private Color hoverTextColor = Color.black;

        [Title("RESOURCES")]
        [SerializeField, Required, AssetsOnly] private AudioInteractable audioInteractable;
        [SerializeField, Required, ChildGameObjectsOnly] private InteractableComponent interactable;
        [SerializeField, Required, ChildGameObjectsOnly] private Image background;
        [SerializeField, Required, ChildGameObjectsOnly] private TextMeshProUGUI text;

        [Title("CLICK EVENT")]
        [SerializeField] protected UnityEvent clickAction;

        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeHoverAnimation;
        public InteractableComponent Interactable => interactable;

        /*******************************************************************/
        private void Start()
        {
            interactable.AddClickAction(ClickEffect);
            interactable.AddHoverOnAction(HoverOnEffect);
            interactable.AddHoverOffAction(HoverOffEffect);
        }

        public void ClickEffect()
        {
            audioInteractable.ClickSound();
            clickAction?.Invoke();
        }

        public void HoverOnEffect()
        {
            audioInteractable.HoverOnSound();
            HoverActivate();
        }
        public void HoverOffEffect()
        {
            audioInteractable.HoverOffSound();
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