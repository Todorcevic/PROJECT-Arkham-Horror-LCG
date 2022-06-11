using DG.Tweening;
using Sirenix.OdinInspector;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class ButtonView : MonoBehaviour
    {
        private bool isLock;
        private bool isInactive;
        public event Action ClickAction;
        [Inject] private InteractableAudio interactableAudio;
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private Image background;
        [SerializeField, Required, ChildGameObjectsOnly] private TextMeshProUGUI text;

        /*******************************************************************/
        public void Desactive(bool isOn)
        {
            ChangeTextColor(isOn ? ViewValues.DESACTIVE_COLOR : isLock ? Color.black : Color.white);
            isInactive = isOn;
        }

        public void Lock(bool isOn)
        {
            HoverActivate(isOn);
            isInactive = isOn;
            isLock = isOn;
        }

        public void PointerClick()
        {
            if (isInactive) return;
            interactableAudio.ClickSound();
            ClickAction?.Invoke();
        }

        public void HoverOnEffect()
        {
            if (isInactive) return;
            interactableAudio.HoverOnSound();
            HoverActivate(true);
        }

        public void HoverOffEffect()
        {
            if (isInactive) return;
            interactableAudio.HoverOffSound();
            HoverActivate(false);
        }

        private void HoverActivate(bool isOn)
        {
            ChangeTextColor(isOn ? Color.black : Color.white);
            background.DOFillAmount(isOn ? 1 : 0, ViewValues.STANDARD_TIME);
        }

        private void ChangeTextColor(Color color) => text.DOColor(color, ViewValues.STANDARD_TIME);
    }
}