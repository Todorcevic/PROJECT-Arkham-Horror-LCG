using Arkham.Services;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Views
{
    public class ButtonView : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [Inject] private readonly IDoubleClickDetector clickDetector;
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private ButtonEffects buttonEffects;

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (clickDetector.CheckDoubleClick(eventData.clickTime, eventData.pointerPress))
                buttonEffects.DoubleClickEffect();
            else buttonEffects.ClickEffect();
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData) => buttonEffects.HoverOnEffect();

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData) => buttonEffects.HoverOffEffect();
    }
}
