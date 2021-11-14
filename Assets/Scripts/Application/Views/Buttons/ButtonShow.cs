using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;
using DG.Tweening;
using Arkham.Config;

namespace Arkham.Application
{
    public class ButtonShow : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private const float SCALE = 1.1f;
        [Inject] private readonly ShowCard showCard;
        [SerializeField, Required] private CardView cardView;
        [SerializeField, Required] private InteractableAudio audioInteractable;

        /*******************************************************************/
        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.pointerDrag || showCard.IsMoving || showCard.IsShow) return;
            showCard.Set(cardView);
            showCard.ShowAnimation();
            audioInteractable.HoverOnSound();
            transform.DOScale(SCALE, ViewValues.FAST_TIME);
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            showCard.Hide();
            audioInteractable.HoverOffSound();
            transform.DOScale(1f, ViewValues.FAST_TIME);
        }
    }
}
