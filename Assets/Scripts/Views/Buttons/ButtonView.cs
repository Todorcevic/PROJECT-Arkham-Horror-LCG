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
        [SerializeField, Required, ChildGameObjectsOnly] private ButtonInteractable buttonInteractable;


        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (clickDetector.CheckDoubleClick(eventData.clickTime, eventData.pointerPress))
                buttonInteractable.DoubleClickEffect();
            else buttonInteractable.ClickEffect();
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData) => buttonInteractable.HoverOnEffect();

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData) => buttonInteractable.HoverOffEffect();
    }
}
