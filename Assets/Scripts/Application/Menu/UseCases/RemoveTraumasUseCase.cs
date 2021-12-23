using Arkham.Application;
using Arkham.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Arkham.Application
{
    public class RemoveTraumasUseCase
    {
        [Inject] private readonly InvestigatorSelectorsManager investigatorSelectorsManager;
        [Inject] private readonly InvestigatorsCardPresenter investigatorCardsPresenter;
        [Inject] private readonly InvestigatorRepository investigatorRepository;
        [Inject] private readonly InvestigatorAvatarView investigatorAvatar;

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
            investigatorAvatar.SetPhysicTrauma(investigator.PhysicTrauma);
            investigatorAvatar.SetMentalTrauma(investigator.MentalTrauma);
            investigatorAvatar.SetXp(investigator.Xp);
            investigatorCardsPresenter.RefreshTokens(investigator);
        }
    }
}
