using DG.Tweening;
using Sirenix.OdinInspector;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Arkham.View
{
    public class InvestigatorSelectorView : MonoBehaviour
    {
        public const string REMOVE_ANIMATION = "RemoveAnimation";

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
        public Vector2 PlaceHolderPosition => PlaceHolder.position;
        public string Id { get; protected set; }
        public bool IsLeader => leaderIcon.enabled;

        /*******************************************************************/
        public void SetSelector(string cardId, Sprite cardSprite)
        {
            Id = sensor.Id = dragSensor.Id = cardId;
            sensor.Activate(true);
            image.sprite = cardSprite;
        }

        public void EmptySelector()
        {
            Id = null;
            sensor.Activate(false);
        }

        public void LeadIcon(bool isOn) => leaderIcon.enabled = isOn;

        public void Glow(bool isOn) => canvasGlow.DOFade(isOn ? 1 : 0, timeAnimation);

        public void SetTransform(Transform toTransform = null)
        {
            PlaceHolder.SetParent(toTransform ? toTransform : this.transform, worldPositionStays: false);
            PlaceHolder.localPosition = Vector3.zero;
        }

        public void SwapPlaceHoldersWith(InvestigatorSelectorView otherSelector)
        {
            int selector1Index = PlaceHolder.GetSiblingIndex();
            PlaceHolder.SetSiblingIndex(otherSelector.PlaceHolder.GetSiblingIndex());
            otherSelector.PlaceHolder.SetSiblingIndex(selector1Index);
        }

        public void SetImageAnimation()
        {
            DOTween.Sequence().PrependCallback(PreConfig)
                .Append(CardVisual.DOScale(1, timeAnimation));

            void PreConfig()
            {
                CardVisual.localScale = Vector3.zero;
                CardVisual.position = PlaceHolder.position;
                canvasImage.alpha = 1;
            }
        }

        public Task RemoveAnimation()
        {
            return DOTween.Sequence()
                .Join(CardVisual.DOMove(PlaceHolder.position, timeAnimation).SetSpeedBased())
                .Join(CardVisual.DOScale(0, timeAnimation))
                .AppendCallback(PostConfig).SetId(REMOVE_ANIMATION)
                .AsyncWaitForCompletion();

            void PostConfig() => canvasImage.alpha = 0;
        }

        public void ArrangeAnimation() => CardVisual.DOMove(PlaceHolder.position, timeAnimation);
    }
}