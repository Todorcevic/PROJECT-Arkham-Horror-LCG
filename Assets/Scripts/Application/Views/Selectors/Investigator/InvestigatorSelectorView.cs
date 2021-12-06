using Arkham.Config;
using DG.Tweening;
using Sirenix.OdinInspector;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Arkham.Application
{
    public class InvestigatorSelectorView : MonoBehaviour
    {
        public const string MOVE_ANIMATION = "MoveAnimation";
        [Inject(Id = "PlaceHoldersZone")] private readonly RectTransform placeHoldersZone;

        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private CanvasGroup canvasGlow;
        [SerializeField, Required, ChildGameObjectsOnly] private CanvasGroup canvasImage;
        [SerializeField, Required, ChildGameObjectsOnly] private Image image;
        [SerializeField, Required, ChildGameObjectsOnly] private InvestigatorSelectorDragController dragSensor;
        [SerializeField, Required, ChildGameObjectsOnly] private CanvasGroup canvasSensor;
        [SerializeField, Required, ChildGameObjectsOnly] private Image leaderIcon;

        private Transform CardVisual => canvasImage.transform;
        private Transform Sensor => dragSensor.transform;
        public InvestigatorSelectorDragController DragSensor => dragSensor;
        public Vector2 SensorPosition => Sensor.position;
        public string Id { get; private set; }
        public bool IsLeader => leaderIcon.enabled;

        /*******************************************************************/
        public void SetSelector(string cardId, Sprite cardSprite)
        {
            Id = dragSensor.Id = cardId;
            ActivateSensor(true);
            canvasImage.alpha = 1;
            image.sprite = cardSprite;
        }

        public void EmptySelector()
        {
            Id = null;
            canvasImage.alpha = 0;
            image.sprite = null;
        }

        public void ActivateSensor(bool isOn)
        {
            canvasSensor.blocksRaycasts = canvasSensor.interactable = isOn;
            Sensor.SetParent(isOn ? placeHoldersZone : transform);
            Sensor.localPosition = Vector3.zero;
        }

        public void LeadIcon(bool isOn) => leaderIcon.enabled = isOn;

        public void Glow(bool isOn) => canvasGlow.DOFade(isOn ? 1 : 0, ViewValues.STANDARD_TIME);

        public void PosicionateCardOn()
        {
            CardVisual.localScale = Vector3.one;
            CardVisual.position = Sensor.position;
        }

        public void PosicionateCardOff()
        {
            CardVisual.localScale = Vector3.zero;
            CardVisual.position = Sensor.position;
        }

        public void SwapPlaceHoldersWith(InvestigatorSelectorView otherSelector)
        {
            int selector1Index = Sensor.GetSiblingIndex();
            Sensor.SetSiblingIndex(otherSelector.Sensor.GetSiblingIndex());
            otherSelector.Sensor.SetSiblingIndex(selector1Index);
        }

        public Tween SetImageAnimation() => DOTween.Sequence()
            .PrependCallback(PosicionateCardOff)
            .Append(CardVisual.DOScale(1, ViewValues.SLOW_TIME));

        public Tween RemoveAnimation() => DOTween.Sequence()
            .Join(CardVisual.DOMove(Sensor.position, ViewValues.SLOW_TIME).SetId(MOVE_ANIMATION))
            .Join(CardVisual.DOScale(0, ViewValues.SLOW_TIME));

        public void ArrangeAnimation() => CardVisual.DOMove(Sensor.position, ViewValues.SLOW_TIME).SetId(MOVE_ANIMATION);
    }
}