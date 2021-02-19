using Arkham.Controllers;
using Arkham.Interactors;
using Arkham.Managers;
using Arkham.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Arkham.Factories
{
    public class SelectorFactory : ISelectorFactory
    {
        [Inject] private readonly IInvestigatorSelectorsManager selectorsManager;
        [Inject] private readonly IInvestigatorsSelectedInteractor investigatorsSelectedInteractor;

        public void BuildSelectors()
        {
            foreach (ISelectorView selector in selectorsManager.Selectors)
                new SelectorController(selector, investigatorsSelectedInteractor);

            investigatorsSelectedInteractor.InitializeSelectors();
        }
    }
}
