using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Arkham.Views
{
    public class InvestigatorSelectorView : MonoBehaviour
    {
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private CanvasGroup canvasGlow;
        [SerializeField, Required, ChildGameObjectsOnly] private CanvasGroup canvasImage;
        [SerializeField, Required, ChildGameObjectsOnly] private Image image;
        [SerializeField, Required, ChildGameObjectsOnly] private InvestigatorSelectorSensor sensor;
        [SerializeField, Required, ChildGameObjectsOnly] private InvestigatorSelectorDragSensor dragSensor;
        [SerializeField, Required, ChildGameObjectsOnly] private Image leaderIcon;
        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeAnimation;

        private Transform CardVisual => canvasImage.transform;
        private Transform PlaceHolder => sensor.transform;
        public string Id { get; protected set; }
        public bool IsEmpty => Id == null;
        public bool IsLeader => leaderIcon.enabled;

        /*******************************************************************/
        public void SetSelector(string cardId, Sprite cardSprite = null)
        {
            Id = sensor.Id = dragSensor.Id = cardId;
            sensor.Activate(!IsEmpty);
            ChangeImage(cardSprite);
        }

        private void ChangeImage(Sprite cardSprite)
        {
            canvasImage.alpha = cardSprite == null ? 0 : 1;
            image.sprite = cardSprite;
        }

        public void LeadIcon(bool isOn) => leaderIcon.enabled = isOn;

        public void Glow(bool isOn) => canvasGlow.DOFade(isOn ? 1 : 0, timeAnimation);

        public void SetTransform(Transform toTransform = null)
        {
            PlaceHolder.SetParent(toTransform ? toTransform : this.transform, worldPositionStays: false);
            PlaceHolder.localPosition = Vector3.zero;
        }

        public int GetPlaceHolderIndex() => PlaceHolder.GetSiblingIndex();

        public void SwapPlaceHolder(int index) => PlaceHolder.SetSiblingIndex(index);

        public void SetImageAnimation() => DOTween.Sequence().Join(CardVisual.DOScale(0, 0))
                .Join(CardVisual.DOMove(PlaceHolder.position, 0))
                .Append(CardVisual.DOScale(1, timeAnimation));

        public void ArrangeAnimation() => CardVisual.DOMove(PlaceHolder.position, timeAnimation);
    }
}