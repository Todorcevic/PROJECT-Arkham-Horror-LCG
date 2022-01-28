﻿using Arkham.Model;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class RemoveTraumasUseCase
    {
        [Inject] private readonly InvestigatorSelectorsManager investigatorSelectorsManager;
        [Inject] private readonly InvestigatorsCardPresenter investigatorCardsPresenter;
        [Inject] private readonly InvestigatorsRepository investigatorRepository;
        [Inject] private readonly AvatarPresenter avatarPresenter;

        public void RemovePhysicTrauma()
        {
            Investigator investigator = investigatorRepository.Get(investigatorSelectorsManager.InvestigatorSelected);
            UpdatePhysicTraumaModel(investigator);
            UpdateView(investigator);
        }

        public void RemoveMentalTrauma()
        {
            Investigator investigator = investigatorRepository.Get(investigatorSelectorsManager.InvestigatorSelected);
            UpdateMentalTraumaModel(investigator);
            UpdateView(investigator);
        }

        private void UpdatePhysicTraumaModel(Investigator investigator)
        {
            investigator.Xp -= GameValues.TRAUMA_COST;
            investigator.PhysicTrauma -= 1;
        }

        private void UpdateMentalTraumaModel(Investigator investigator)
        {
            investigator.Xp -= GameValues.TRAUMA_COST;
            investigator.MentalTrauma -= 1;
        }

        private void UpdateView(Investigator investigator)
        {
            avatarPresenter.UpdateAvatar(investigator);
            investigatorCardsPresenter.RefreshTokens(investigator);
        }
    }
}
