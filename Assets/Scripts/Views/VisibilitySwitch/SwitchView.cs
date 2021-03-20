using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Sirenix.OdinInspector;
using DG.Tweening;
using System;

namespace Arkham.Views
{
    public enum Switch
    {
        Visibility
    }


    public class SwitchView : MonoBehaviour, IPointerClickHandler, ISwitch
    {
        private event Action<PointerEventData> Clicked;
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private InteractableAudio interactableAudio;
        [SerializeField, Required] private Transform positionOn;
        [SerializeField, Required] private Transform positionOff;
        [SerializeField, Required] private Image button;
        [SerializeField, Required] private Image background;
        [SerializeField, Required] private Image border;
        [Title("SETTINGS")]
        [SerializeField] private bool saveValue;
        [SerializeField, Range(0f, 1f)] private float timeMoveAnimation;
        [SerializeField] private Color colorOn;
        [SerializeField] private Color colorOff;

        bool ISwitch.SaveValue => saveValue;

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData) => Clicked?.Invoke(eventData);

        void ISwitch.ClickSound() => interactableAudio.ClickSound();

        void ISwitch.AnimateSwitch(bool isOn)
        {
            button.transform.DOMove(isOn ? positionOn.position : positionOff.position, timeMoveAnimation);
            button.DOColor(isOn ? colorOff : colorOn, timeMoveAnimation);
            border.DOColor(isOn ? colorOff : colorOn, timeMoveAnimation);
            background.DOColor(isOn ? colorOn : colorOff, timeMoveAnimation);
        }

        void ISwitch.AddEvent(Action<PointerEventData> action) => Clicked += action;
    }
}