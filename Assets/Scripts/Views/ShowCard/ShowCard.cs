using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Arkham.Views
{
    public class ShowCard : MonoBehaviour, IShowCard
    {
        private IShowable currentShowableCard;
        private Vector2 finalPosition;
        const string SHOWCARD_ANIMATION = "ShowCardAnimation";
        const string MOVE_ANIMATION = "MoveAnimation";
        [Inject] private readonly IImageCardsManager imageCards;
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private Image frontImage;
        [SerializeField, Required, ChildGameObjectsOnly] private Image backImage;
        [SerializeField, Required, ChildGameObjectsOnly] private Transform showCard;
        [SerializeField, Required, SceneObjectsOnly] private Transform cardSelector;
        [SerializeField, Required, SceneObjectsOnly] private Transform cardZone;
        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeAnimation;
        [SerializeField, Range(0f, 1f)] private float delay;
        [SerializeField, Range(1f, 2f)] private float scale;
        [SerializeField, Range(-1000f, 1000f)] private float leftOffSet;
        [SerializeField, Range(-1000f, 1000f)] private float rightOffSet;

        private float AxisYMiddleScreen => Screen.height * 0.5f;
        public Transform Transform => frontImage.transform;

        /*******************************************************************/

        public void ShowInRightSide(IShowable showableCard)
        {
            finalPosition = new Vector2(showableCard.Position.x + rightOffSet, AxisYMiddleScreen);
            StartCoroutine(Show(showableCard, finalPosition));
        }

        public void ShowInLeftSide(IShowable showableCard)
        {
            finalPosition = new Vector2(showableCard.Position.x + leftOffSet, AxisYMiddleScreen);
            StartCoroutine(Show(showableCard, finalPosition));
        }

        private IEnumerator Show(IShowable showableCard, Vector2 finalPosition)
        {

            currentShowableCard = showableCard;
            yield return new WaitWhile(() => DOTween.IsTweening(MOVE_ANIMATION));
            if (currentShowableCard == null) yield break;
            MoveShowCard(showableCard.Position);
            ActiveFrontImage(showableCard);
            ActiveBackImage(showableCard);
            ShowAnimation(finalPosition, scale);
        }

        public void HidePreviewCard()
        {
            currentShowableCard = null;
            Hide();
        }

        private void Hide()
        {
            if (DOTween.IsTweening(MOVE_ANIMATION)) return;
            DOTween.Kill(SHOWCARD_ANIMATION);
            frontImage.gameObject.SetActive(false);
            backImage.gameObject.SetActive(false);
            showCard.localScale = Vector2.zero;
        }

        private void MoveShowCard(Vector2 position) => showCard.position = position;

        private void ActiveFrontImage(IShowable showableCard)
        {
            frontImage.gameObject.SetActive(true);
            frontImage.color = showableCard.ImageColor;
            frontImage.sprite = imageCards.GetSprite(showableCard.CardId);
        }

        private void ActiveBackImage(IShowable showableCard)
        {
            if (!imageCards.ExistThisSprite(showableCard.CardId)) return;
            backImage.gameObject.SetActive(true);
            backImage.color = showableCard.ImageColor;
            backImage.sprite = imageCards.GetBackSprite(showableCard.CardId);
        }

        private void ShowAnimation(Vector2 position, float scale = 0)
        {
            Tween tweeneMove = showCard.DOMove(position, timeAnimation).SetDelay(delay);
            Tween tweenScale = showCard.DOScale(scale, timeAnimation).SetDelay(delay);
            DOTween.Sequence().Append(tweeneMove).Join(tweenScale).SetId(SHOWCARD_ANIMATION);
        }

        public void AddMoveAnimation()
        {
            Tween tweeneMove = showCard.DOMove(cardSelector.position, timeAnimation);
            Tween tweenScale = showCard.DOScale(0, timeAnimation);
            DOTween.Sequence().Append(tweeneMove).Join(tweenScale).SetId(MOVE_ANIMATION)
                    .OnComplete(Reshow);
        }

        public void RemoveMoveAnimation(bool withReshow)
        {
            Tween tweeneMove = showCard.DOMove(cardZone.position, timeAnimation);
            Tween tweenScale = showCard.DOScale(0, timeAnimation);
            DOTween.Sequence().Append(tweeneMove).Join(tweenScale).SetId(MOVE_ANIMATION)
                .OnComplete(Reshow);
        }

        private void Reshow()
        {
            Hide();
            if (currentShowableCard != null) StartCoroutine(Show(currentShowableCard, finalPosition));
        }
    }
}
