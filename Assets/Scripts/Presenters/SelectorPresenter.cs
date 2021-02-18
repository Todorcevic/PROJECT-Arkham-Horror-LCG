using Arkham.Controllers;
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
        [Inject] private readonly ISelectorsManager selectorManager;
        [Inject] private readonly ICardComponentRepository cardRepository;

        public (ISelectorView selector, CardController investigatorcard) SetInvestigator(string investigatorId)
        {
            ISelectorView selector = selectorManager.GetSelectorVoid();
            CardController investigatorcard = cardRepository.AllCardViews[investigatorId];
            selector.SetInvestigator(investigatorId, investigatorcard.GetCardImage);
            return (selector, investigatorcard);
        }

        public void AddInvestigator(string investigatorId)
        {
            (ISelectorView selector, CardController investigatorCard) = SetInvestigator(investigatorId);
            selector.MoveTo(investigatorCard.Transform);
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
