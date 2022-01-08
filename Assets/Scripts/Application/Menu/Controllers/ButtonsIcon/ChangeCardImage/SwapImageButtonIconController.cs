using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class SwapImageButtonIconController : MonoBehaviour
    {
        [Inject] private readonly ImagesCardService imageCards;
        [Inject] private readonly CardImagePresenter cardImagePresenter;
        [SerializeField, Required] private ButtonIconView changeImage;

        /*******************************************************************/
        public void Init(CardView cardView)
        {
            changeImage.ClickAction += Clicked;
            CheckShowButton();

            void Clicked() => cardImagePresenter.ChangeAllImagesWithAnimation(cardView.Id);
            void CheckShowButton() => changeImage.gameObject.SetActive(imageCards.CanChange(cardView.Id));
        }
    }
}
