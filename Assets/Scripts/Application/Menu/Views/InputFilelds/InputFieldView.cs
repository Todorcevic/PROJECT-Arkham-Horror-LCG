using DG.Tweening;
using Sirenix.OdinInspector;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Arkham.Application.MainMenu
{
    public class InputFieldView : MonoBehaviour
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
        public void Selected(bool isSelected) => background.color = isSelected ? ViewValues.ACTIVE_COLOR : ViewValues.DESACTIVE_COLOR;

        public void UpdateText()
        {
            if (field.text == CurrentText) return;
            CurrentText = field.text;
            UpdateAction?.Invoke();
        }

        public void HoverOnEffect()
        {
            textField.fontStyle = FontStyles.Bold;
            icon.transform.DOScale(SCALE, ViewValues.STANDARD_TIME);
        }


        public void HoverOffEffect()
        {
            textField.fontStyle = FontStyles.Normal;
            icon.transform.DOScale(1f, ViewValues.STANDARD_TIME);
        }
    }
}
