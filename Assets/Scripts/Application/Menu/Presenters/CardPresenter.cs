using DG.Tweening;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class CardPresenter
    {
        [Inject] private readonly CardsManager cardsManager;
        [Inject] private readonly ImagesCardService imageCards;

        /*******************************************************************/
        public Tween ChangeImagesWithAnimation(string cardId)
        {
            CardView cardView = cardsManager.GetCard(cardId);
            return DOTween.Sequence().Append(cardView.transform.DORotate(Vector3.up * 90, ViewValues.FAST_TIME))
                    .AppendCallback(() => SetCardImage(cardView))
                    .Append(cardView.transform.DORotate(Vector3.zero, ViewValues.FAST_TIME));
        }

        public void SetCardImage(CardView cardView)
        {
            Sprite frontImage = imageCards.GetSprite(cardView.Id);
            Sprite backImage = imageCards.GetSprite(cardView.Id, isBack: true);
            cardView.ChangeImage(frontImage, backImage);
        }
    }
}
