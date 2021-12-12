using UnityEngine;
using UnityEngine.EventSystems;
using Sirenix.OdinInspector;
using DG.Tweening;
using Arkham.Config;
using Zenject;

namespace Arkham.Application
{
    public abstract class CardController : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IDropHandler
    {
        private const string SHAKE = "Shake";
        [Inject] private readonly CardShowerPresenter cardShowerPresenter;
        [Inject] private readonly CardShowerManager cardShowerManager;
        [SerializeField, Required] protected CardView cardView;
        [SerializeField, Required, ChildGameObjectsOnly] protected InteractableAudio audioInteractable;

        /*******************************************************************/
        protected abstract void Clicked(PointerEventData eventData);

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData) => Clicked(eventData);

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.dragging) return;
            cardView.Glow.DOFade(1, ViewValues.STANDARD_TIME);
            audioInteractable.HoverOnSound();
            cardShowerPresenter.AddShowableAndShow(cardView);
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            cardView.Glow.DOFade(0, ViewValues.STANDARD_TIME);
            cardShowerPresenter.RemoveShowableAndHide(cardView);
        }

        void IDropHandler.OnDrop(PointerEventData eventData)
        {
            if (cardShowerManager.CheckIsShow(cardView)) return;
            cardView.Glow.DOFade(1, ViewValues.STANDARD_TIME);
            audioInteractable.HoverOnSound();
            cardShowerPresenter.AddShowableAndShow(cardView);
        }

        protected void CantAdd()
        {
            DOTween.Complete(SHAKE + gameObject.GetInstanceID());
            transform.DOPunchPosition(Vector3.right * 20, ViewValues.FAST_TIME, 40, 5).SetId(SHAKE + gameObject.GetInstanceID());
        }
    }
}
