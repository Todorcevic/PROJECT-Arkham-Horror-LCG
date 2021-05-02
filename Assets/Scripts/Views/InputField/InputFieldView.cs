using Arkham.Model;
using DG.Tweening;
using Sirenix.OdinInspector;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Arkham.Views
{
    public class InputFieldView : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler,
        IPointerExitHandler, IUpdateSelectedHandler
    {
        private event Action UpdateAction;
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private TMP_InputField field;
        [SerializeField, Required, ChildGameObjectsOnly] private TextMeshProUGUI textField;
        [SerializeField, Required, ChildGameObjectsOnly] private Image background;
        [SerializeField, Required, ChildGameObjectsOnly] private Image icon;
        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeHoverAnimation;
        [SerializeField, Range(1f, 2f)] private float hoverScale;
        [SerializeField] private Color deselectColor;
        [SerializeField] private Color selectColor;

        public string CurrentText { get; private set; }

        /*******************************************************************/
        public void AddUpdateAction(Action action) => UpdateAction += action;

        void ISelectHandler.OnSelect(BaseEventData eventData) => background.color = selectColor;

        void IDeselectHandler.OnDeselect(BaseEventData eventData) => background.color = deselectColor;

        void IUpdateSelectedHandler.OnUpdateSelected(BaseEventData eventData)
        {
            if (field.text == CurrentText) return;
            CurrentText = field.text;
            UpdateAction.Invoke();
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            textField.fontStyle = FontStyles.Bold;
            icon.transform.DOScale(hoverScale, timeHoverAnimation);
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            textField.fontStyle = FontStyles.Normal;
            icon.transform.DOScale(1f, timeHoverAnimation);
        }
    }
}
