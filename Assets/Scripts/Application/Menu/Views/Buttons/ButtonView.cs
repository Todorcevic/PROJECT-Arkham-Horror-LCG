using DG.Tweening;
using Sirenix.OdinInspector;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class ButtonView : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        private bool isLock;
        private bool isInactive;
        public event Action ClickAction;
        [Title("RESOURCES")]
        [Inject] private InteractableAudio interactableAudio;
        [SerializeField, Required, ChildGameObjectsOnly] private Image background;
        [SerializeField, Required, ChildGameObjectsOnly] private TextMeshProUGUI text;

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (eventData.dragging || isInactive) return;
            interactableAudio.ClickSound();
            ClickAction?.Invoke();
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.dragging || isInactive) return;
            interactableAudio.HoverOnSound();
            HoverActivate(true);
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            if (eventData.dragging || isInactive) return;
            interactableAudio.HoverOffSound();
            HoverActivate(false);
        }

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

        private void HoverActivate(bool isOn)
        {
            ChangeTextColor(isOn ? Color.black : Color.white);
            background.DOFillAmount(isOn ? 1 : 0, ViewValues.STANDARD_TIME);
        }

        private void ChangeTextColor(Color color) => text.DOColor(color, ViewValues.STANDARD_TIME);
    }
}