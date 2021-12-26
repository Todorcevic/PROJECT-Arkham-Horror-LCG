using Zenject;

namespace Arkham.Application.MainMenu
{

    public class TraumasButtonIconController : IInitializable
    {
        [Inject] private readonly RemoveTraumasUseCase removeTraumasUseCase;
        [Inject(Id = "PhysicTraumaButton")] private readonly ButtonIconView physicTraumaButton;
        [Inject(Id = "MentalTraumaButton")] private readonly ButtonIconView mentalTraumaButton;

        /*******************************************************************/
        public void Initialize()
        {
            physicTraumaButton.ClickAction += removeTraumasUseCase.RemovePhysicTrauma;
            mentalTraumaButton.ClickAction += removeTraumasUseCase.RemoveMentalTrauma;
        }
    }
}