using Arkham.Services;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;
using DG.Tweening;
using Arkham.Config;

namespace Arkham.Application
{
    public class ChangeCardImageController : MonoBehaviour
    {
        private int imageNumber;
        private CardView cardView;

        [Inject] private readonly ICardImage imageCards;
        [Inject] private readonly IPlayerPrefsAdapter playerPref;
        [SerializeField, Required, ChildGameObjectsOnly] private ButtonIcon changeImage;

        private string CardImageName => cardView.Id + (imageNumber > 0 ? "-" + imageNumber : string.Empty);

        /*******************************************************************/
        public void Init(CardView cardView)
        {
            this.cardView = cardView;
            SetController();
            CheckActivateButton();
            ChangeCardImage();

            void CheckActivateButton() => changeImage.gameObject.SetActive(imageCards.CanChange(cardView.Id));
        }

        private void SetController()
        {
            imageNumber = playerPref.LoadImageNumber(cardView.Id);
            changeImage.ClickAction += (_) => ChangeImage();

            void ChangeImage()
            {
                imageNumber++;
                if (!imageCards.ExistThisSprite(CardImageName)) imageNumber = 0;
                ChangeCardImageAnimation();
                playerPref.SaveChangeImage(cardView.Id, imageNumber);
            }

            void ChangeCardImageAnimation()
            {
                DOTween.Sequence()
                    .Append(cardView.transform.DORotate(Vector3.up * 90, ViewValues.FAST_TIME))
                    .AppendCallback(ChangeCardImage)
                    .Append(cardView.transform.DORotate(Vector3.zero, ViewValues.FAST_TIME));
            }
        }

        private void ChangeCardImage() => cardView.ChangeImage(imageCards.GetSprite(CardImageName), imageCards.GetBackSprite(CardImageName));
    }
}
