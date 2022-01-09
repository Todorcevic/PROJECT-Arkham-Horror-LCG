using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class CardPresenter
    {
        [Inject] private readonly CardsManager cardsManager;
        [Inject] private readonly ImagesCardService imageCards;
        [Inject] private readonly DotweenService dotweenService;

        /*******************************************************************/
        public Tween ChangeImagesWithAnimation(string cardId)
        {
            CardView cardView = cardsManager.GetCard(cardId);
            return dotweenService.SwapImage(cardView.transform, () => SetCardImage(cardView));
        }

        public void SetCardImage(CardView cardView)
        {
            Sprite frontImage = imageCards.GetSprite(cardView.Id);
            Sprite backImage = imageCards.GetSprite(cardView.Id, isBack: true);
            cardView.ChangeImage(frontImage, backImage);
        }
    }
}
