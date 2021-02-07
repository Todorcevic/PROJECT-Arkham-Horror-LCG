using UnityEngine;
using Arkham.Views;
using Arkham.Repositories;
using UnityEngine.EventSystems;
using Arkham.Investigators;
using Arkham.Adapters;

namespace Arkham.Presenters
{
    public class CardInvestigatorPresenter : IPresenter<ICardInvestigatorView>
    {
        private readonly ContextJson repository;

        public CardInvestigatorPresenter(ContextJson repository)
        {
            this.repository = repository;
        }

        public void CreateReactiveViewModel(ICardInvestigatorView objectView)
        {
            //playerData.ObserveEveryValueChanged(playerData => playerData.Campaigns[campaignButton.Id])
            //    .Subscribe(campaignStateId => campaignStates[campaignStateId].SetState(campaignButton));
        }

    }
}
