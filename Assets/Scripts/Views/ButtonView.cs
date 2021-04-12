using DG.Tweening;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Arkham.Views
{
    public class ButtonView : MonoBehaviour
    {
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private InteractableAudio interactableAudio;
        [SerializeField, Required, ChildGameObjectsOnly] private Image background;
        [SerializeField, Required, ChildGameObjectsOnly] private TextMeshProUGUI text;
        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeHoverAnimation;
        [SerializeField] private Color desactiveColor;

        public string Id { get; set; }
        public bool IsInactive { get; set; }

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

        public void Desactive(bool isOn)
        {
            ChangeTextColor(isOn ? desactiveColor : Color.white);
            IsInactive = isOn;
        }

        public void Lock(bool isOn)
        {
            if (isOn) HoverActivate();
            else HoverDesactivate();
            IsInactive = isOn;
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

        private void ChangeTextColor(Color color) => text.DOColor(color, timeHoverAnimation);

        private void FillBackground(bool toFill) => background.DOFillAmount(toFill ? 1 : 0, timeHoverAnimation);
    }
}