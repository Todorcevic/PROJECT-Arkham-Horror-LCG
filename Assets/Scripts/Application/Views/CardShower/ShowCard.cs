using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Arkham.Application
{
    public class ShowCard : MonoBehaviour
    {
        private CardView cardView;
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private Image frontImage;
        [SerializeField, Required, ChildGameObjectsOnly] private Image backImage;
        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeAnimation;
        [SerializeField, Range(1f, 2f)] private float scale;
        [SerializeField, Range(0f, 1f)] private float dragScale;

        public bool IsMoving => DOTween.IsTweening(MoveTweenId);
        public bool IsShowing => DOTween.IsTweening(ShowTweenId);

        private static string ShowTweenId => "Show";
        private static string MoveTweenId => "Move";
        private Vector2 ShowCardPosition => new Vector2(cardView.transform.position.x - 175, Screen.height * 0.5f);

        /*******************************************************************/
        public void Set(CardView cardView)
        {
            this.cardView = cardView;
            transform.position = cardView.transform.position;
            ActiveFrontImage();
            ActiveBackImage();

            void ActiveFrontImage()
            {
                frontImage.gameObject.SetActive(cardView.GetCardImage != null);
                frontImage.sprite = cardView.GetCardImage;
            }

            void ActiveBackImage()
            {
                backImage.gameObject.SetActive(cardView.GetBackImage != null);
                backImage.sprite = cardView.GetBackImage;
            }
        }

        public void Hide()
        {
            DOTween.Kill(ShowTweenId);
            transform.localScale = Vector2.zero;
            cardView = null;
        }

        public Tween ShowAnimation() => DOTween.Sequence()
            .Append(transform.DOMove(ShowCardPosition, timeAnimation))
            .Join(transform.DOScale(scale, timeAnimation))
            .SetDelay(MoveTimeLeft(), true).SetId(ShowTweenId);

        public static float MoveTimeLeft()
        {
            Tween move = DOTween.TweensById(MoveTweenId)?.FirstOrDefault();
            return move?.Duration() - move?.Elapsed() ?? 0;
        }

        public Tween MoveAnimation(Vector2 positionToMove) => DOTween.Sequence()
            .Append(transform.DOMove(positionToMove, timeAnimation))
            .Join(transform.DOScale(0, timeAnimation))
            .OnComplete(ReShow)
            .SetId(MoveTweenId);

        private void ReShow()
        {
            DOTween.Complete(MoveTweenId);
            if (cardView == null) return;
            Set(cardView);
            ShowAnimation();
        }

        public void Dragging()
        {
            DOTween.Kill(ShowTweenId);
            DesactiveBackImage();
            transform.DOScale(dragScale, timeAnimation);

            void DesactiveBackImage()
            {
                backImage.gameObject.SetActive(false);
                backImage.sprite = null;
            }
        }
    }
}
