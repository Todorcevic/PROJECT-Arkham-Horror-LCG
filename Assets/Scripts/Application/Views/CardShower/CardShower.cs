using Arkham.Config;
using DG.Tweening;
using Sirenix.OdinInspector;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Arkham.Application
{
    public class CardShower : MonoBehaviour
    {
        private bool isShow;
        private IShowable showableCard;
        private const float SCALE = 1.6f;
        private const float DRAG_SCALE = 0.6f;
        private const string ShowTweenId = "Show";
        private const string MoveTweenId = "Move";
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private Image frontImage;
        [SerializeField, Required, ChildGameObjectsOnly] private Image backImage;

        /*******************************************************************/
        public void AddShowableAndShow(IShowable currentShowableCard)
        {
            showableCard = currentShowableCard;
            CheckShowableCard();
        }

        public void RemoveShowableAndHide()
        {
            showableCard = null;
            Hide();
        }

        private void CheckShowableCard()
        {
            if (showableCard == null) return;
            if (DOTween.IsTweening(MoveTweenId)) return;
            if (isShow) return;
            PrepareShowableCard();
            Show();
        }

        private void Show()
        {
            DOTween.Sequence()
           .Append(transform.DOMove(showableCard.ShowPosition, ViewValues.STANDARD_TIME))
           .Join(transform.DOScale(SCALE, ViewValues.STANDARD_TIME))
           .SetId(ShowTweenId);
            isShow = true;
        }

        private void Hide()
        {
            if (DOTween.IsTweening(MoveTweenId)) return;
            DOTween.Kill(ShowTweenId);
            transform.localScale = Vector2.zero;
            isShow = false;
        }

        public void Move(Vector2 positionToMove)
        {
            DOTween.Kill(MoveTweenId);
            if (isShow)
            {
                DOTween.Sequence().Append(transform.DOMove(positionToMove, ViewValues.STANDARD_TIME))
                .Join(transform.DOScale(0, ViewValues.STANDARD_TIME))
                .OnComplete(CheckShowableCard).SetId(MoveTweenId);
            }
            else
            {
                PrepareShowableCard();
                DOTween.Sequence()
                .Append(transform.DOMove(showableCard.ShowPosition, ViewValues.STANDARD_TIME))
                .Join(transform.DOScale(SCALE, ViewValues.STANDARD_TIME))
                .Append(transform.DOMove(positionToMove, ViewValues.STANDARD_TIME))
                .Join(transform.DOScale(0, ViewValues.STANDARD_TIME))
                .OnComplete(CheckShowableCard).SetId(MoveTweenId);
            }

            isShow = false;
        }

        private void PrepareShowableCard()
        {
            transform.localScale = Vector3.zero;
            transform.position = showableCard.StartPosition;
            if (frontImage.sprite != showableCard.FrontImage) ActiveFrontImage();
            if (backImage.sprite != showableCard.BackImage) ActiveBackImage();

            void ActiveFrontImage()
            {
                frontImage.gameObject.SetActive(showableCard.FrontImage != null);
                frontImage.sprite = showableCard.FrontImage;
            }

            void ActiveBackImage()
            {
                bool withBack = backImage.sprite != null;
                backImage.gameObject.SetActive(withBack && showableCard.BackImage != null);
                backImage.sprite = showableCard.BackImage;
            }
        }
    }
}
