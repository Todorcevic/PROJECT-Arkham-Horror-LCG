using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Arkham.Views
{
    public class InvestigatorSelectorView : MonoBehaviour
    {
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private ImageController imageController;
        [SerializeField, Required, ChildGameObjectsOnly] private GlowActivator glowActivator;
        [SerializeField, Required, ChildGameObjectsOnly] private Transform card;
        [SerializeField, Required, ChildGameObjectsOnly] private InvestigatorSelectorSensor sensor;
        [SerializeField, Required, ChildGameObjectsOnly] private InvestigatorSelectorDragSensor dragSensor;
        [SerializeField, Required, ChildGameObjectsOnly] private Image leaderIcon;
        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeAnimation;

        private Transform PlaceHolder => sensor.transform;
        public string Id { get; protected set; }
        public bool IsEmpty => Id == null;
        public bool IsLeader => leaderIcon.enabled;

        /*******************************************************************/
        public void SetSelector(string cardId, Sprite cardImage = null)
        {
            Id = sensor.Id = dragSensor.Id = cardId;
            sensor.Activate(!IsEmpty);
            imageController.ChangeImage(cardImage);
        }
        public void LeadIcon(bool isOn) => leaderIcon.enabled = isOn;

        public void Glow(bool isOn) => glowActivator.ActivateGlow(isOn);

        public void SetTransform(Transform toTransform = null)
        {
            PlaceHolder.SetParent(toTransform ? toTransform : this.transform, worldPositionStays: false);
            PlaceHolder.localPosition = Vector3.zero;
        }

        public void SwapPlaceHolderWith(InvestigatorSelectorView otherSelector)
        {
            int indexToSwap = otherSelector.PlaceHolder.GetSiblingIndex();
            otherSelector.PlaceHolder.SetSiblingIndex(PlaceHolder.GetSiblingIndex());
            PlaceHolder.SetSiblingIndex(indexToSwap);
        }

        public void SetImageAnimation() => DOTween.Sequence().Join(card.DOScale(0, 0))
                .Join(card.DOMove(PlaceHolder.position, 0))
                .Append(card.DOScale(1, timeAnimation));

        public void ArrangeAnimation() => card.DOMove(PlaceHolder.position, timeAnimation);
    }
}