using Zenject;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using Arkham.Config;
using Arkham.Model;

namespace Arkham.Application
{
    public class InvestigatorSelectorPresenter
    {
        [Inject] private readonly StartGameUseCase startGameUseCase;
        [Inject] private readonly Selector selector;


        [Inject] private readonly CardsManager cardsManager;
        [Inject] private readonly InvestigatorSelectorsManager investigatorSelectorsManager;
        [Inject] private readonly SelectInvestigatorUseCase investigatorSelectUseCase;
        [Inject] private readonly CardShowerPresenter cardShowerController;
        [Inject(Id = "InvestigatorPlaceHolderZone")] private readonly RectTransform placeHoldersZone;

        private InvestigatorSelectorView LeadSelector => investigatorSelectorsManager.GetCurrentLeadSelector;

        /*******************************************************************/
        public void InitializeSelectors()
        {
            investigatorSelectorsManager.ResetSelectors();
            AddAllInvestigators();
            investigatorSelectUseCase.SelectLead();

            void AddAllInvestigators()
            {
                foreach (string investigatorId in selector.InvestigatorsIdInSelector)
                    InitInvestigator(investigatorId);

                void InitInvestigator(string investigatorId)
                {
                    InvestigatorSelectorView selector = investigatorSelectorsManager.GetEmptySelector();
                    SetThisSelectorWithThisInvestigator(selector, investigatorId);
                    selector.PosicionateCardOn();
                }
            }
        }

        public void SetLeadSelector()
        {
            string realLeadInvestigator = selector.Lead?.Id;
            if (realLeadInvestigator == null || realLeadInvestigator == LeadSelector?.Id) return;
            LeadSelector?.LeadIcon(false);
            investigatorSelectorsManager.GetSelectorById(realLeadInvestigator).LeadIcon(true);
        }

        public void AddInvestigator(string investigatorId)
        {
            InvestigatorSelectorView selector = investigatorSelectorsManager.GetEmptySelector();
            SetThisSelectorWithThisInvestigator(selector, investigatorId);
            Animation();

            async void Animation()
            {
                await cardShowerController.AddInvestigatorAnimation(selector.PlaceHolderPosition);
                selector.SetImageAnimation();
            }
        }

        public async void RemoveInvestigator(string investigatorId)
        {
            InvestigatorSelectorView selector = investigatorSelectorsManager.GetSelectorById(investigatorId);
            selector.SetTransform();
            await Animation();
            selector.EmptySelector();

            async Task Animation()
            {
                investigatorSelectorsManager.RebuildPlaceHolders();
                investigatorSelectorsManager.ArrangeAllSelectors();
                await selector.RemoveAnimation();
            }
        }

        public void ChangeInvestigator(string investigatorId1, string investigatorId2)
        {
            InvestigatorSelectorView selector1 = investigatorSelectorsManager.GetSelectorById(investigatorId1);
            InvestigatorSelectorView selector2 = investigatorSelectorsManager.GetSelectorById(investigatorId2);
            selector1.SwapPlaceHoldersWith(selector2);
            Animation();

            void Animation()
            {
                investigatorSelectorsManager.RebuildPlaceHolders();
                selector1.ArrangeAnimation();
            }
        }

        public void SelectInvestigator(string activeInvestigatorId) =>
            investigatorSelectorsManager.SelectInvestigator(activeInvestigatorId);



        private void SetThisSelectorWithThisInvestigator(InvestigatorSelectorView selector, string investigatorId)
        {
            Sprite spriteCard = cardsManager.GetSpriteCard(investigatorId);
            selector.SetTransform(placeHoldersZone);
            selector.SetSelector(investigatorId, spriteCard);
            investigatorSelectorsManager.RebuildPlaceHolders();
        }
    }
}
