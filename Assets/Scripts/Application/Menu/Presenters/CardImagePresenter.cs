using DG.Tweening;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class CardImagePresenter
    {
        [Inject] private readonly CardsManager cardsManager;
        [Inject] private readonly ImagesCardService imageCards;
        [Inject] private readonly PlayerPrefsService playerPref;
        [Inject] private readonly InvestigatorAvatarView avatarView;
        [Inject] private readonly InvestigatorSelectorsManager investigatorSelectorsManager;

        /*******************************************************************/
        public void ChangeAllImagesWithAnimation(string cardId)
        {
            CardView cardView = cardsManager.GetCard(cardId);
            SaveImageSelected();
            ChangeCardImageAnimation();

            void SaveImageSelected()
            {
                int imageNumber = playerPref.LoadImageNumber(cardId) + 1;
                if (!imageCards.ExistThisSprite(cardId + "-" + imageNumber)) imageNumber = 0;
                playerPref.SaveChangeImage(cardId, imageNumber);
            }

            void ChangeCardImageAnimation()
            {
                DOTween.Sequence().Append(cardView.transform.DORotate(Vector3.up * 90, ViewValues.FAST_TIME))
                    .AppendCallback(ChangeFull)
                    .Append(cardView.transform.DORotate(Vector3.zero, ViewValues.FAST_TIME));

                void ChangeFull()
                {
                    SetCardImage(cardView);
                    ChangeAvatar();
                    ChangeSelector();

                    void ChangeAvatar()
                    {
                        if (investigatorSelectorsManager.InvestigatorSelected == cardView.Id)
                            avatarView.ChangeImage(cardView.FrontImage);
                    }

                    void ChangeSelector() => investigatorSelectorsManager.GetSelectorById(cardView.Id)?.ChangeImage(cardView.FrontImage);
                }
            }
        }

        public void SetCardImage(CardView cardView)
        {
            Sprite frontImage = imageCards.GetSprite(cardView.Id);
            Sprite backImage = imageCards.GetSprite(cardView.Id, isBack: true);
            cardView.ChangeImage(frontImage, backImage);
        }
    }
}
