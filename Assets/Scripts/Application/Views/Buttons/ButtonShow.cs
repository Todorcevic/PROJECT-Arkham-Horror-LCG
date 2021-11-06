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
        [Inject] protected readonly ShowCard showCard;
        [SerializeField, Required] private CardView cardView;
        [SerializeField, Required] protected InteractableAudio audioInteractable;

        /*******************************************************************/
        public void OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.pointerDrag) return;
            showCard.Set(cardView);
            showCard.ShowAnimation();
            audioInteractable.HoverOnSound();
            transform.DOScale(SCALE, ViewValues.FAST_TIME);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (eventData.pointerDrag) return;
            showCard.Hide();
            audioInteractable.HoverOffSound();
            transform.DOScale(1f, ViewValues.FAST_TIME);
        }
    }
}
