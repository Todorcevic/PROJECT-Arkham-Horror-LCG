using Arkham.Components;
using Arkham.Presenters;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Arkham.Views
{
    public class ShowCard : MonoBehaviour, IShowCard
    {
        private ICardVisualizable cardView;
        const string SHOWCARD_ANIMATION = "ShowCardAnimation";
        const string SHOWCARD_MOVE_ANIMATION = "ShowCardMoveAnimation";
        [Inject] protected readonly IImageCardsManager imageCards;
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private Image frontImage;
        [SerializeField, Required, ChildGameObjectsOnly] private Image backImage;
        [SerializeField, Required, ChildGameObjectsOnly] private Transform showCard;
        [SerializeField, Required, SceneObjectsOnly] private Transform cardSelector;
        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeAnimation;
        [SerializeField, Range(0f, 1f)] private float delay;
        [SerializeField, Range(1f, 2f)] private float scale;
        [SerializeField, Range(-1000f, 1000f)] private float horizontalOffSet;

        private float AxisYMiddleScreen => Screen.height * 0.5f;

        /*******************************************************************/
        public void ShowingPreviewCard(ICardVisualizable cardView)
        {
            this.cardView = cardView;
            MoveShowCard();
            ActiveFrontImage();
            ActiveBackImage();
            Vector2 finalPosition = CalculatePosition();
            ShowAnimation(finalPosition);
        }

        public void HidePreviewCard()
        {
            DOTween.Kill(SHOWCARD_ANIMATION);
            DOTween.Kill(SHOWCARD_MOVE_ANIMATION);
            frontImage.gameObject.SetActive(false);
            backImage.gameObject.SetActive(false);
            showCard.localScale = Vector2.zero;
        }

        private void MoveShowCard() => showCard.position = cardView.Transform.position;

        private void ActiveFrontImage()
        {
            frontImage.gameObject.SetActive(true);
            frontImage.color = cardView.IsInactive ? Color.gray : Color.white;
            frontImage.sprite = imageCards.GetSprite(cardView.Id);
        }

        private void ActiveBackImage()
        {
            if (!imageCards.ExistThisSprite(cardView.Id)) return;
            backImage.gameObject.SetActive(true);
            backImage.color = cardView.IsInactive ? Color.gray : Color.white;
            backImage.sprite = imageCards.GetBackSprite(cardView.Id);
        }

        private Vector2 CalculatePosition() => new Vector2(cardView.Transform.position.x - horizontalOffSet, AxisYMiddleScreen);

        private void ShowAnimation(Vector2 position)
        {
            Tween tweeneMove = showCard.DOMove(position, timeAnimation).SetDelay(delay);
            Tween tweenScale = showCard.DOScale(scale, timeAnimation).SetDelay(delay);
            DOTween.Sequence().Append(tweeneMove).Join(tweenScale).SetId(SHOWCARD_ANIMATION);
        }

        public void MoveAnimation()
        {
            Tween tweeneMove = showCard.DOMove(cardSelector.position, timeAnimation);
            Tween tweenScale = showCard.DOScale(0, timeAnimation);
            DOTween.Sequence().Append(tweeneMove).Join(tweenScale).SetId(SHOWCARD_MOVE_ANIMATION)
                    .OnComplete(ReShow);

            void ReShow()
            {
                HidePreviewCard();
                ShowingPreviewCard(cardView);
            }
        }
    }
}
