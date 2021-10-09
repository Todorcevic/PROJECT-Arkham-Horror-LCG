﻿using Arkham.Model;
using Zenject;

namespace Arkham.Application
{
    public class UpdateXpUseCase
    {
        [Inject] private readonly InvestigatorAvatarView investigatorAvatar;
        [Inject] private readonly CardXpCostInteractor XpCostInteractor;

        /*******************************************************************/
        public void PayCardXp(Investigator investigator, Card card)
        {
            UpdateModel(investigator, XpCostInteractor.XpPayCost(card.Id, investigator.Id));
            UpdateView(investigator);
        }

        private void UpdateModel(Investigator investigator, int amount) => investigator.Xp -= amount;

        private void UpdateView(Investigator investigator) => investigatorAvatar.SetXp(investigator.Xp);
    }
}