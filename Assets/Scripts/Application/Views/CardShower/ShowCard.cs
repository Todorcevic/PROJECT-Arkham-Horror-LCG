using Arkham.Config;
using DG.Tweening;
using Sirenix.OdinInspector;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Arkham.Application
{
    public class ShowCard : MonoBehaviour
    {
        private IShowable showableCard;
        private const float SCALE = 1.6f;
        private const float DRAG_SCALE = 0.6f;
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private Image frontImage;
        [SerializeField, Required, ChildGameObjectsOnly] private Image backImage;

        private static string ShowTweenId => "Show";
        private static string MoveTweenId => "Move";
        public bool IsShowing => showableCard != null;

        /*******************************************************************/
        public void Set()
        {
            if (!IsShowing) Set(showableCard);
        }

        public void Set(IShowable showableCard)
        {
            this.showableCard = showableCard;
            transform.position = showableCard.StartPosition;
            ActiveFrontImage();
            ActiveBackImage();

            void ActiveFrontImage()
            {
                frontImage.gameObject.SetActive(showableCard.FrontImage != null);
                frontImage.sprite = showableCard.FrontImage;
            }

            void ActiveBackImage()
            {
                backImage.gameObject.SetActive(showableCard.BackImage != null);
                backImage.sprite = showableCard.BackImage;
            }
        }

        public Tween ShowAnimation() => DOTween.Sequence()
            .Append(transform.DOMove(showableCard.Position, ViewValues.STANDARD_TIME))
            .Join(transform.DOScale(SCALE, ViewValues.STANDARD_TIME))
            .SetDelay(MoveTimeLeft(), true).SetId(ShowTweenId);

        public void Hide()
        {
            DOTween.Kill(ShowTweenId);
            transform.localScale = Vector2.zero;
            showableCard = null;
        }

        public static float MoveTimeLeft()
        {
            Tween move = DOTween.TweensById(MoveTweenId)?.FirstOrDefault();
            return move?.Duration() - move?.Elapsed() ?? 0;
        }

        public Tween MoveAnimation(Vector2 positionToMove) => DOTween.Sequence()
            .Append(transform.DOMove(positionToMove, ViewValues.STANDARD_TIME))
            .Join(transform.DOScale(0, ViewValues.STANDARD_TIME))
            .OnComplete(Hide).SetId(MoveTweenId);

        public void Dragging()
        {
            DOTween.Kill(ShowTweenId);
            DesactiveBackImage();
            transform.DOScale(DRAG_SCALE, ViewValues.STANDARD_TIME);

            void DesactiveBackImage()
            {
                backImage.gameObject.SetActive(false);
                backImage.sprite = null;
            }
        }
    }
}
