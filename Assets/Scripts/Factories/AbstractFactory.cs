using Arkham.Controllers;
using Arkham.Presenters;
using Arkham.Views;
using System.Collections.Generic;
using Zenject;

namespace Arkham.Factories
{
    public class AbstractFactory : IAbstractFactory
    {
        [Inject] private readonly List<IInitializableController> controllers;
        [Inject] private readonly List<IInitializablePresenter> presenters;

        /*******************************************************************/
        public void Init()
        {
            for (int i = 0; i < controllers.Count; i++)
                Build(presenters[i], controllers[i]);
        }

        private void Build(IInitializablePresenter presenter, IInitializableController controller)
        {
            foreach (IInteractableView interactableView in presenter.interactableViews)
            {
                interactableView.Interactable.Init();
                controller.Init(interactableView);
            }

            presenter.Init();
        }
    }
}

