using Arkham.Application;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Arkham.Application
{
    public class ShowCardView : MonoBehaviour
    {
        private const float SCALE = 1.6f;
        private const string ShowTweenId = "Show";
        private const string MoveTweenId = "Move";

        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private Image frontImage;
        [SerializeField, Required, ChildGameObjectsOnly] private Image backImage;

        public bool IsShowing { get; set; }
        public bool IsMoving => DOTween.IsTweening(MoveTweenId + GetInstanceID());
        public IShowable ShowableCard { get; set; }

        /*******************************************************************/
        public void SetShowableCard(IShowable showableCard)
        {
            IsShowing = true;
            ShowableCard = showableCard;
            transform.localScale = Vector3.zero;
            transform.position = showableCard.StartPosition;

            ActiveFrontImage();
            ActiveBackImage();

            void ActiveFrontImage()
            {
                frontImage.gameObject.SetActive(showableCard.FrontImage != null);
                frontImage.sprite = showableCard.FrontImage;
                frontImage.color = showableCard.IsInactive ? Color.gray : Color.white;
            }

            void ActiveBackImage()
            {
                backImage.gameObject.SetActive(showableCard.BackImage != null);
                backImage.sprite = showableCard.BackImage;
                backImage.color = showableCard.IsInactive ? Color.gray : Color.white;
            }
        }

        public void Clean()
        {
            IsShowing = false;
            ShowableCard = null;
        }

        public void Hide()
        {
            DOTween.Kill(ShowTweenId + GetInstanceID());
            transform.localScale = Vector2.zero;
        }

        public void ShowAnimation(Vector3 toPosition)
        {
            DOTween.Sequence()
               .Append(transform.DOMove(toPosition, ViewValues.SLOW_TIME))
               .Join(transform.DOScale(SCALE, ViewValues.SLOW_TIME))
               .SetId(ShowTweenId + GetInstanceID());
        }

        public void MoveAnimation(Vector3 toPosition)
        {
            DOTween.Sequence().Append(transform.DOMove(toPosition, ViewValues.SLOW_TIME))
                .Join(transform.DOScale(0, ViewValues.SLOW_TIME)).SetId(MoveTweenId + GetInstanceID());
        }
    }
}
