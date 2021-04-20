using UnityEngine;
using TMPro;
using Sirenix.OdinInspector;
using UnityEngine.EventSystems;
using Zenject;
using UnityEngine.UI;
using DG.Tweening;

namespace Arkham.Views
{
    public class InputFieldView : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler, IUpdateSelectedHandler
    {
        [Inject] private readonly ISearchController controller;
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private TMP_InputField field;
        [SerializeField, Required, ChildGameObjectsOnly] private TextMeshProUGUI searchText;
        [SerializeField, Required, ChildGameObjectsOnly] private Image background;
        [SerializeField, Required, ChildGameObjectsOnly] private Image icon;
        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeHoverAnimation;
        [SerializeField, Range(1f, 2f)] private float hoverScale;
        [SerializeField] private Color deselectColor;
        [SerializeField] private Color selectColor;

        /*******************************************************************/
        public void OnSelect(BaseEventData eventData) => background.color = selectColor;

        public void OnDeselect(BaseEventData eventData) => background.color = deselectColor;

        public void OnUpdateSelected(BaseEventData eventData) => controller.UpdateText(field.text);

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            searchText.fontStyle = FontStyles.Bold;
            icon.transform.DOScale(hoverScale, timeHoverAnimation);
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            searchText.fontStyle = FontStyles.Normal;
            icon.transform.DOScale(1f, timeHoverAnimation);
        }
    }
}
