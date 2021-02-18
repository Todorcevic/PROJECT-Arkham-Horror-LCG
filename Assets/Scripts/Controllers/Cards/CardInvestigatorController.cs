using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Arkham.Models;
using Arkham.Investigators;
using Zenject;
using Arkham.Services;
using UnityEngine.EventSystems;
using Arkham.Managers;
using Arkham.Repositories;
using Arkham.Iterators;

namespace Arkham.Controllers
{
    public class CardInvestigatorController : CardController, ICardInvestigatorController
    {
        [Inject] IInvestigatorsSelectedInteractor selectorIterator;
        public InvestigatorInfo Investigator { get; set; }
        protected override int AmountSelected => selectorIterator.AmountInvestigators(Investigator.Id);

        /*******************************************************************/
        protected override void DoubleClick() => selectorIterator.AddInvestigator(Investigator.Id);
    }
}
