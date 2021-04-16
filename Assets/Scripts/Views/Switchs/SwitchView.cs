using DG.Tweening;
using Sirenix.OdinInspector;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Arkham.Views
{
    public class SwitchView : MonoBehaviour, IPointerClickHandler, IClickable
    {
        private event Action Clicked;
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private InteractableAudio interactableAudio;
        [SerializeField, Required] private Transform positionOn;
        [SerializeField, Required] private Transform positionOff;
        [SerializeField, Required] private Image button;
        [SerializeField, Required] private Image background;
        [SerializeField, Required] private Image border;
        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeMoveAnimation;
        [SerializeField] private Color colorOn;
        [SerializeField] private Color colorOff;

        /*******************************************************************/
        public void ClickSound() => interactableAudio.ClickSound();

        public void SwitchAnimation(bool isOn)
        {
            button.transform.DOMove(isOn ? positionOn.position : positionOff.position, timeMoveAnimation);
            button.DOColor(isOn ? colorOff : colorOn, timeMoveAnimation);
            border.DOColor(isOn ? colorOff : colorOn, timeMoveAnimation);
            background.DOColor(isOn ? colorOn : colorOff, timeMoveAnimation);
        }
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData) => Clicked?.Invoke();

        void IClickable.AddAction(Action action) => Clicked += action;
    }
}
