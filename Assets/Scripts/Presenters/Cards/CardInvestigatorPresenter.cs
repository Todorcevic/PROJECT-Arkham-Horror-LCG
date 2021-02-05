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

        void IPresenter<CardInvestigatorView>.CreateReactiveViewModel(CardInvestigatorView objectView)
        {
            CreateReactiveModel(objectView);
        }

        void IClickPresenter<CardInvestigatorView>.Click(CardInvestigatorView cardInvestigatorView, PointerEventData eventData)
        {
            //CardInvestigatorView cardInView = objectView as CardInvestigatorView;
            //repository.AllInvestigatorSelectors["ONE"].InvestigatorId = cardInvestigatorView.Id;
        }

        void IFullInteractablePresenter<CardInvestigatorView>.HoverOff(CardInvestigatorView cardInvestigatorView, PointerEventData eventData)
        {

        }

        void IFullInteractablePresenter<CardInvestigatorView>.HoverOn(CardInvestigatorView cardInvestigatorView, PointerEventData eventData)
        {

        }

        private void CreateReactiveModel(CardInvestigatorView cardInvestigatorComponent)
        {
            //playerData.ObserveEveryValueChanged(playerData => playerData.Campaigns[campaignButton.Id])
            //    .Subscribe(campaignStateId => campaignStates[campaignStateId].SetState(campaignButton));
        }
    }
}
