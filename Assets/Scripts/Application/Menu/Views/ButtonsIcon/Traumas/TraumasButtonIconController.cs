using System;
using Zenject;

namespace Arkham.Application.MainMenu
{

    public class TraumasButtonIconController : IInitializable, IDisposable
    {
        [Inject] private readonly RemoveTraumasUseCase removeTraumasUseCase;
        [Inject(Id = "PhysicTraumaButton")] private readonly ButtonIconView physicTraumaButton;
        [Inject(Id = "MentalTraumaButton")] private readonly ButtonIconView mentalTraumaButton;

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            physicTraumaButton.ClickAction += removeTraumasUseCase.RemovePhysicTrauma;
            mentalTraumaButton.ClickAction += removeTraumasUseCase.RemoveMentalTrauma;
        }

        void IDisposable.Dispose()
        {
            physicTraumaButton.ClickAction -= removeTraumasUseCase.RemovePhysicTrauma;
            mentalTraumaButton.ClickAction -= removeTraumasUseCase.RemoveMentalTrauma;
        }
    }
}