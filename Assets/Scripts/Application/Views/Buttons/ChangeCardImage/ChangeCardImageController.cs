using Arkham.Services;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;
using System.Linq;

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
        }

        private void SetController()
        {
            imageNumber = playerPref.LoadImageNumber(cardView.Id);
            changeImage.ClickAction += (_) => ChangeImage();

            void ChangeImage()
            {
                imageNumber++;
                if (!imageCards.ExistThisSprite(CardImageName)) imageNumber = 0;
                ChangeCardImage();
                playerPref.SaveChangeImage(cardView.Id, imageNumber);
            }
        }

        private void CheckActivateButton() => changeImage.gameObject.SetActive(imageCards.CanChange(cardView.Id));

        private void ChangeCardImage() => cardView.ChangeImage(imageCards.GetSprite(CardImageName), imageCards.GetBackSprite(CardImageName));
    }
}
