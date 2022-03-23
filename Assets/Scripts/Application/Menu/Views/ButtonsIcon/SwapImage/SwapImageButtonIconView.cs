﻿using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class SwapImageButtonIconView : ButtonIconView
    {
        [Inject] private readonly SwapImageCardUseCase swapImageCardUseCase;
        [Inject] private readonly ImagesCardService imagesCard;
        [Title("DEPENDENCIES")]
        [SerializeField, Required] private CardView cardView;

        /*******************************************************************/
        private void Start() => Activate(imagesCard.CanChange(cardView.Id));
        private void OnEnable() => ClickAction += Clicked;
        private void OnDisable() => ClickAction -= Clicked;

        /*******************************************************************/
        private void Clicked() => swapImageCardUseCase.ChangeCardImage(cardView.Id);
    }
}