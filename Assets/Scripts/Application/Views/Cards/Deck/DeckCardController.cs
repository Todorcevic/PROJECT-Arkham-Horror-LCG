using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Arkham.Application
{
    public class DeckCardController : CardController
    {
        [Inject] private readonly InvestigatorSelectorsManager investigatorSelectorManager;
        [Inject] private readonly AddCardUseCase addCardUseCase;

        /*******************************************************************/
        protected override void Clicked() =>
            addCardUseCase.AddCard(cardView.Id, investigatorSelectorManager.CurrentInvestigatorId);

    }
}
