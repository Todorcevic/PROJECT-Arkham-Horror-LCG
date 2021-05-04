using Arkham.Model;
using Zenject;
using Arkham.Adapter;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

namespace Arkham.Views
{
    public class InvestigatorSelectorPresenter
    {
        private string investigatorSelected;
        [Inject] private readonly CardsManager cardsManager;
        [Inject] private readonly InvestigatorSelectorsManager investigatorSelectorsManager;
        [Inject] private readonly SelectInvestigatorUseCase investigatorSelectEvent;
        [Inject] private readonly Selector selector;
        [Inject] private readonly CardShowerPresenter cardShowerController;
        [Inject(Id = "InvestigatorPlaceHolderZone")] private readonly RectTransform placeHoldersZone;

        private InvestigatorSelectorView LeadSelector => investigatorSelectorsManager.GetLeadSelector;

        /*******************************************************************/
        public void InitializeSelectors(List<string> investigators)
        {
            investigatorSelectorsManager.ResetSelectors();
            AddAllInvestigators();
            SetLeadSelector();
            investigatorSelectEvent.SelectCurrentOrLead();

            void AddAllInvestigators()
            {
                foreach (string investigatorId in investigators)
                    InitInvestigator(investigatorId);

                void InitInvestigator(string investigatorId)
                {
                    InvestigatorSelectorView selector = investigatorSelectorsManager.GetEmptySelector();
                    SetThisSelectorWithThisInvestigator(selector, investigatorId);
                    selector.PosicionateCardOn();
                }
            }
        }

        public void AddInvestigator(string investigatorId)
        {
            InvestigatorSelectorView selector = investigatorSelectorsManager.GetEmptySelector();
            SetThisSelectorWithThisInvestigator(selector, investigatorId);
            SetLeadSelector();
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
            SetLeadSelector();
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
            SetLeadSelector();
            Animation();

            void Animation()
            {
                investigatorSelectorsManager.RebuildPlaceHolders();
                selector1.ArrangeAnimation();
            }
        }

        public void SelectInvestigator(string activeInvestigatorId)
        {
            RemoveGlowInOldInvestigator();
            ActiveGlowInNewInvestigator();
            investigatorSelected = activeInvestigatorId;

            void RemoveGlowInOldInvestigator() =>
          investigatorSelectorsManager.GetSelectorById(investigatorSelected)?.Glow(false);

            void ActiveGlowInNewInvestigator() =>
              investigatorSelectorsManager.GetSelectorById(activeInvestigatorId)?.Glow(true);
        }

        private void SetThisSelectorWithThisInvestigator(InvestigatorSelectorView selector, string investigatorId)
        {
            Sprite spriteCard = cardsManager.GetSpriteCard(investigatorId);
            selector.SetTransform(placeHoldersZone);
            selector.SetSelector(investigatorId, spriteCard);
            investigatorSelectorsManager.RebuildPlaceHolders();
        }

        private void SetLeadSelector()
        {
            if (selector.Lead == null || selector.Lead.Id == LeadSelector?.Id) return;
            LeadSelector?.LeadIcon(false);
            investigatorSelectorsManager.GetSelectorById(selector.Lead.Id).LeadIcon(true);
        }
    }
}
