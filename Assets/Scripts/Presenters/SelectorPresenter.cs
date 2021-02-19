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

        public ISelectorView SetInvestigator(string investigatorId)
        {
            ISelectorView selector = selectorManager.GetSelectorVoid();
            Sprite spriteCard = investigatorManager.GetSpriteCard(investigatorId);
            selector.SetInvestigator(investigatorId, spriteCard);
            return selector;
        }

        public void AddInvestigator(string investigatorId, bool isEnable)
        {
            ISelectorView selector = SetInvestigator(investigatorId);
            IInvestigatorCardView investigatorCardView = investigatorManager.AllInvestigatorCards[investigatorId];
            investigatorCardView.Enable(isEnable);
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
