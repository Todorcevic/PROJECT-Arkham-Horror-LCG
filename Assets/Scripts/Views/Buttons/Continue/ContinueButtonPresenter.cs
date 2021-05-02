using Arkham.Config;
using Arkham.Adapter;
using System.IO;
using Zenject;

namespace Arkham.Views
{
    public class ContinueButtonPresenter : IInitializable
    {
        [Inject] private readonly ScenarioEventDomain scenarioEvent;
        [Inject] private readonly GameFiles gameFiles;
        [Inject(Id = "ContinueButton")] private readonly ButtonView continueButton;

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            scenarioEvent.Subscribe(DesactiveButton);
            continueButton.Desactive(!CanContinue());
        }

        /*******************************************************************/
        private void DesactiveButton(string scenario) => continueButton.Desactive(scenario == null);

        private bool CanContinue() => File.Exists(gameFiles.PlayerProgressFilePath);
    }
}
