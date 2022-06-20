using DG.Tweening;
using Sirenix.OdinInspector;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Arkham.Application.MainMenu
{
    public class ButtonView : MonoBehaviour
    {
        private bool isLock;
        public event Action ClickAction;
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private Image background;
        [SerializeField, Required, ChildGameObjectsOnly] private TextMeshProUGUI text;

        public bool IsInactive { get; private set; }

        /*******************************************************************/
        public void Desactive(bool isOn)
        {
            ChangeTextColor(isOn ? ViewValues.DESACTIVE_COLOR : isLock ? Color.black : Color.white);
            IsInactive = isOn;
        }

        public void Lock(bool isOn)
        {
            HoverActivate(isOn);
            IsInactive = isOn;
            isLock = isOn;
        }

        public void PointerClick() => ClickAction?.Invoke();

        public void HoverActivate(bool isOn)
        {
            ChangeTextColor(isOn ? Color.black : Color.white);
            background.DOFillAmount(isOn ? 1 : 0, ViewValues.STANDARD_TIME);
        }

        private void ChangeTextColor(Color color) => text.DOColor(color, ViewValues.STANDARD_TIME);
    }
}