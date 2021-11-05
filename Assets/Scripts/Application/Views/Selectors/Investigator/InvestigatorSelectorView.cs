using Arkham.Config;
using DG.Tweening;
using Sirenix.OdinInspector;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Arkham.Application
{
    public class InvestigatorSelectorView : MonoBehaviour
    {
        public const string REMOVE_ANIMATION = "RemoveAnimation";

        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private CanvasGroup canvasGlow;
        [SerializeField, Required, ChildGameObjectsOnly] private CanvasGroup canvasImage;
        [SerializeField, Required, ChildGameObjectsOnly] private Image image;
        [SerializeField, Required, ChildGameObjectsOnly] private InvestigatorSelectorDragController dragSensor;
        [SerializeField, Required, ChildGameObjectsOnly] private CanvasGroup canvasSensor;
        [SerializeField, Required, ChildGameObjectsOnly] private Image leaderIcon;

        private Transform CardVisual => canvasImage.transform;
        private Transform PlaceHolder => dragSensor.transform;
        public InvestigatorSelectorDragController DragSensor => dragSensor;
        public Vector2 PlaceHolderPosition => PlaceHolder.position;
        public string Id { get; protected set; }
        public bool IsLeader => leaderIcon.enabled;

        /*******************************************************************/
        public void SetSelector(string cardId, Sprite cardSprite)
        {
            Id = dragSensor.Id = cardId;
            Activate(true);
            canvasImage.alpha = 1;
            image.sprite = cardSprite;
        }

        public void EmptySelector()
        {
            Id = null;
            Activate(false);
            canvasImage.alpha = 0;
            image.sprite = null;
        }

        public void ResetSelector()
        {
            EmptySelector();
            Glow(false);
            SetTransform();
        }

        public void LeadIcon(bool isOn) => leaderIcon.enabled = isOn;

        public void Glow(bool isOn) => canvasGlow.DOFade(isOn ? 1 : 0, ViewValues.STANDARD_TIME);

        public void SetTransform(Transform toTransform = null)
        {
            PlaceHolder.SetParent(toTransform ? toTransform : transform, worldPositionStays: false);
            PlaceHolder.localPosition = Vector3.zero;
        }

        public void PosicionateCardOn()
        {
            CardVisual.localScale = Vector3.one;
            CardVisual.position = PlaceHolder.position;
        }

        public void PosicionateCardOff()
        {
            CardVisual.localScale = Vector3.zero;
            CardVisual.position = PlaceHolder.position;
        }

        public void SwapPlaceHoldersWith(InvestigatorSelectorView otherSelector)
        {
            int selector1Index = PlaceHolder.GetSiblingIndex();
            PlaceHolder.SetSiblingIndex(otherSelector.PlaceHolder.GetSiblingIndex());
            otherSelector.PlaceHolder.SetSiblingIndex(selector1Index);
        }

        public Tween SetImageAnimation() => DOTween.Sequence()
            .PrependCallback(PosicionateCardOff)
            .Append(CardVisual.DOScale(1, ViewValues.STANDARD_TIME))
            .SetDelay(ShowCard.MoveTimeLeft(), true);

        public Tween RemoveAnimation() => DOTween.Sequence()
            .Join(CardVisual.DOMove(PlaceHolder.position, ViewValues.STANDARD_TIME * 4).SetSpeedBased())
            .Join(CardVisual.DOScale(0, ViewValues.STANDARD_TIME)).SetId(REMOVE_ANIMATION);

        public void ArrangeAnimation() => CardVisual.DOMove(PlaceHolder.position, ViewValues.STANDARD_TIME);

        private void Activate(bool isOn) => canvasSensor.blocksRaycasts = canvasSensor.interactable = isOn;
    }
}