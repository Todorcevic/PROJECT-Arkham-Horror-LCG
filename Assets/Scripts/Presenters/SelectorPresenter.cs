using Arkham.Controllers;
using Arkham.Interactors;
using Arkham.Managers;
using Arkham.Repositories;
using Arkham.Views;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Arkham.Presenters
{
    public class SelectorPresenter : ISelectorPresenter
    {
        [Inject] private readonly IInvestigatorSelectorsManager selectorManager;
        [Inject] private readonly IInvestigatorCardsManager investigatorManager;

        /*******************************************************************/
        public ISelectorView SetInvestigator(string investigatorId)
        {
            ISelectorView selector = selectorManager.GetSelectorVoid();
            Sprite spriteCard = investigatorManager.GetSpriteCard(investigatorId);
            selector.SetInvestigator(investigatorId, spriteCard);
            return selector;
        }

        public void FocusInvestigator(string activeInvestigatorId, string desactiveInvestigatorId)
        {
            selectorManager.GetSelectorByInvestigator(desactiveInvestigatorId)?.ActivateGlow(false);
            selectorManager.GetSelectorByInvestigator(activeInvestigatorId)?.ActivateGlow(true);
        }

        public void AddInvestigator(string investigatorId)
        {
            ISelectorView selector = SetInvestigator(investigatorId);
            IInvestigatorCardView investigatorCardView = investigatorManager.AllInvestigatorCards[investigatorId];
            selector.MoveTo(investigatorCardView.Transform);
            selectorManager.ArrangeSelectors();
        }

        public void RemoveInvestigator(string investigatorId)
        {
            ISelectorView selector = selectorManager.GetSelectorByInvestigator(investigatorId);
            selector.SetInvestigator(null);
            selectorManager.ArrangeSelectors();
        }
    }
}
