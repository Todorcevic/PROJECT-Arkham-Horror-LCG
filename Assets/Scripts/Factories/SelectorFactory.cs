﻿using Arkham.Controllers;
using Arkham.Interactors;
using Arkham.Managers;
using Arkham.Repositories;
using Arkham.UseCases;
using Arkham.Views;
using Zenject;

namespace Arkham.Factories
{
    public class SelectorFactory : ISelectorFactory
    {
        [Inject] private readonly ISelectorController selectorController;
        [Inject] private readonly IInvestigatorSelectorsManager selectorsManager;
        [Inject] private readonly IInvestigatorsSelectorInteractor investigatorsSelectedInteractor;

        /*******************************************************************/
        public void BuildSelectors()
        {
            foreach (ISelectorView selector in selectorsManager.Selectors)
                selectorController.Init(selector);

            investigatorsSelectedInteractor.InitializeSelectors();
        }
    }
}
