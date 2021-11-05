using Arkham.Config;
using DG.Tweening;
using Sirenix.OdinInspector;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Arkham.Application
{
    public class InputFieldView : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler,
        IPointerExitHandler, IUpdateSelectedHandler
    {
        private const float SCALE = 1.2f;
        public event Action UpdateAction;
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private TMP_InputField field;
        [SerializeField, Required, ChildGameObjectsOnly] private TextMeshProUGUI textField;
        [SerializeField, Required, ChildGameObjectsOnly] private Image background;
        [SerializeField, Required, ChildGameObjectsOnly] private Image icon;

        public string CurrentText { get; private set; }

        /*******************************************************************/
        void ISelectHandler.OnSelect(BaseEventData eventData) => background.color = ViewValues.ACTIVE_COLOR;

        void IDeselectHandler.OnDeselect(BaseEventData eventData) => background.color = ViewValues.DESACTIVE_COLOR;

        void IUpdateSelectedHandler.OnUpdateSelected(BaseEventData eventData)
        {
            if (field.text == CurrentText) return;
            CurrentText = field.text;
            UpdateAction?.Invoke();
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.dragging) return;
            textField.fontStyle = FontStyles.Bold;
            icon.transform.DOScale(SCALE, ViewValues.STANDARD_TIME);
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            textField.fontStyle = FontStyles.Normal;
            icon.transform.DOScale(1f, ViewValues.STANDARD_TIME);
        }
    }
}
