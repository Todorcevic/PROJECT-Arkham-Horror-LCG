using DG.Tweening;
using Sirenix.OdinInspector;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Arkham.Application
{
    public class SwitchView : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        private const float TIME_MOVE = 0.5f;
        private const float TIME_HOVER = 0.1f;
        private const float SCALE = 1.25f;
        private Color colorOn = Color.white;
        private Color colorOff = Color.black;
        public event Action ClickAction;
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private InteractableAudio interactableAudio;
        [SerializeField, Required] private Transform positionOn;
        [SerializeField, Required] private Transform positionOff;
        [SerializeField, Required] private Image button;
        [SerializeField, Required] private Image background;
        [SerializeField, Required] private Image border;
        [SerializeField, Required] private TextMeshProUGUI title;

        public bool IsOn { get; private set; }

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            interactableAudio.ClickSound();
            SwitchAnimation(!IsOn);
            ClickAction?.Invoke();
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.dragging) return;
            interactableAudio.HoverOnSound();
            title.fontStyle = FontStyles.Bold;
            button.transform.DOScale(SCALE, TIME_HOVER);
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            interactableAudio.HoverOffSound();
            title.fontStyle = FontStyles.Normal;
            button.transform.DOScale(1f, TIME_HOVER);
        }

        public void SwitchAnimation(bool isOn)
        {
            button.transform.DOMove(isOn ? positionOn.position : positionOff.position, TIME_MOVE);
            button.DOColor(isOn ? colorOff : colorOn, TIME_MOVE);
            border.DOColor(isOn ? colorOff : colorOn, TIME_MOVE);
            background.DOColor(isOn ? colorOn : colorOff, TIME_MOVE);
            IsOn = isOn;
        }
    }
}
