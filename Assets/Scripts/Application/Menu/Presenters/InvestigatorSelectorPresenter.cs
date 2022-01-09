using Zenject;
using UnityEngine;
using Arkham.Model;
using DG.Tweening;

namespace Arkham.Application.MainMenu
{
    public class InvestigatorSelectorPresenter
    {
        [Inject] private readonly SelectorsRepository selectorRepository;
        [Inject] private readonly CardsManager cardsManager;
        [Inject] private readonly InvestigatorSelectorsManager investigatorSelectorsManager;
        [Inject] private readonly SelectInvestigatorUseCase investigatorSelectUseCase;

        private InvestigatorSelectorView LeadSelector => investigatorSelectorsManager.GetCurrentLeadSelector;

        /*******************************************************************/
        public void InitializeSelectors()
        {
            investigatorSelectorsManager.ResetSelectors();
            AddAllInvestigators();
            investigatorSelectUseCase.SelectLead();

            void AddAllInvestigators()
            {
                foreach (string investigatorId in selectorRepository.InvestigatorsIdInSelector)
                {
                    InvestigatorSelectorView selector = investigatorSelectorsManager.GetEmptySelector();
                    SetThisSelectorWithThisInvestigator(selector, investigatorId);
                    selector.PosicionateCardOn();
                }
            }
        }

        public void SetLeadSelector()
        {
            string realLeadInvestigator = selectorRepository.Lead?.Id;
            if (realLeadInvestigator == null || realLeadInvestigator == LeadSelector?.Id) return;
            LeadSelector?.LeadIcon(false);
            investigatorSelectorsManager.GetSelectorById(realLeadInvestigator).LeadIcon(true);
        }

        public InvestigatorSelectorView AddInvestigatorToSelector(string investigatorId)
        {
            InvestigatorSelectorView selector = investigatorSelectorsManager.GetEmptySelector();
            SetThisSelectorWithThisInvestigator(selector, investigatorId);
            return selector;
        }

        private void SetThisSelectorWithThisInvestigator(InvestigatorSelectorView selector, string investigatorId)
        {
            Sprite spriteCard = cardsManager.GetSpriteCard(investigatorId);
            selector.SetSelector(investigatorId, spriteCard);
            investigatorSelectorsManager.RebuildPlaceHolders();
        }

        public void RemoveInvestigator(string investigatorId)
        {
            InvestigatorSelectorView selector = investigatorSelectorsManager.GetSelectorById(investigatorId);
            selector.ActivateSensor(false);
            Animation();

            void Animation()
            {
                investigatorSelectorsManager.ArrangeAllSelectors();
                selector.RemoveAnimation().OnComplete(selector.EmptySelector);
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

        public void SwapImageSelector(string cardId)
        {
            Sprite image = cardsManager.GetCard(cardId).FrontImage;
            investigatorSelectorsManager.GetSelectorById(cardId)?.ChangeImage(image);
        }
    }
}
