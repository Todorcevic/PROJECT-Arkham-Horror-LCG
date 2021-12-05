using Arkham.Config;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Arkham.Application
{
    public class ShowCard : MonoBehaviour
    {
        private const float SCALE = 1.6f;
        private const string ShowTweenId = "Show";
        public const string MoveTweenId = "Move";

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
                if (frontImage.sprite == showableCard.FrontImage) return;
                frontImage.gameObject.SetActive(showableCard.FrontImage != null);
                frontImage.sprite = showableCard.FrontImage;
            }

            void ActiveBackImage()
            {
                if (backImage.sprite == showableCard.BackImage) return;
                bool withBack = backImage.sprite != null;
                backImage.gameObject.SetActive(withBack && showableCard.BackImage != null);
                backImage.sprite = showableCard.BackImage;
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
               .Append(transform.DOMove(toPosition, ViewValues.STANDARD_TIME))
               .Join(transform.DOScale(SCALE, ViewValues.STANDARD_TIME))
               .SetId(ShowTweenId + GetInstanceID());
        }

        public void MoveAnimation(Vector3 toPosition)
        {
            DOTween.Sequence().Append(transform.DOMove(toPosition, ViewValues.STANDARD_TIME))
                .Join(transform.DOScale(0, ViewValues.STANDARD_TIME)).SetId(MoveTweenId + GetInstanceID());
        }
    }
}
