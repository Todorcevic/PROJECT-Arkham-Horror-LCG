using UnityEngine;
using Arkham.Views;
using Arkham.Repositories;
using UnityEngine.EventSystems;
using Arkham.Investigators;
using Arkham.Adapters;

namespace Arkham.Presenters
{
    public class CardInvestigatorPresenter : IFullInteractablePresenter<CardInvestigatorView>
    {
        private readonly ContextJson repository;

        public CardInvestigatorPresenter(ContextJson repository)
        {
            this.repository = repository;
        }

        public void CreateReactiveViewModel(CardInvestigatorView objectView)
        {
            CreateReactiveModel(objectView);
        }

        public void Click(CardInvestigatorView cardInvestigatorView, PointerEventData eventData)
        {
            //CardInvestigatorView cardInView = objectView as CardInvestigatorView;
            //repository.AllInvestigatorSelectors["ONE"].InvestigatorId = cardInvestigatorView.Id;
        }

        public void HoverOff(CardInvestigatorView cardInvestigatorView, PointerEventData eventData)
        {

        }

        public void HoverOn(CardInvestigatorView cardInvestigatorView, PointerEventData eventData)
        {

        }

        private void CreateReactiveModel(CardInvestigatorView cardInvestigatorComponent)
        {
            //playerData.ObserveEveryValueChanged(playerData => playerData.Campaigns[campaignButton.Id])
            //    .Subscribe(campaignStateId => campaignStates[campaignStateId].SetState(campaignButton));
        }
    }
}
