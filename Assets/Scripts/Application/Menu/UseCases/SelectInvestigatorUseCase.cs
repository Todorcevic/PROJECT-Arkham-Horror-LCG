﻿using Arkham.Model;
using UnityEngine;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class SelectInvestigatorUseCase
    {
        [Inject] private readonly SelectorsRepository selector;
        [Inject] private readonly InvestigatorsRepository investigatorRepository;
        [Inject] private readonly DeckCardPresenter cardVisibility;
        [Inject] private readonly CardsQuantityView cardQuantity;
        [Inject] private readonly InvestigatorAvatarView investigatorAvatar;
        [Inject(Id = "RetireButton")] private readonly ButtonIconView retireButton;
        [Inject] private readonly CardSelectorPresenter cardSelector;
        [Inject] private readonly InvestigatorSelectorsManager investigatorSelectorsManager;
        [Inject] private readonly CardsManager investigatorCardsManager;

        /*******************************************************************/
        public void SelectLead() => Select(selector.Lead?.Id);

        public void Select(string investigatorId)
        {
            Investigator investigator = investigatorRepository.Get(investigatorId);
            Sprite imageCard = investigatorCardsManager.GetSpriteCard(investigator?.Id);
            investigatorAvatar.SetAvatar(imageCard, investigator?.PhysicTrauma ?? 0, investigator?.MentalTrauma ?? 0, investigator?.Xp ?? 0);
            retireButton.Activate(investigator?.State == InvestigatorState.None && investigator!.IsPlaying);
            investigatorSelectorsManager.SelectInvestigator(investigatorId);
            cardQuantity.Refresh(investigator);
            cardVisibility.RefreshCardsSelectability();
            cardVisibility.RefreshCardsVisibility();
            cardSelector.ShowAllCards(investigator);
            cardSelector.SetCanBeRemovedInSelectors(investigatorId);
        }
    }
}
