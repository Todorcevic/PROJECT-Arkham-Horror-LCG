using Zenject;

namespace Arkham.Application
{

    public class TraumasController : IInitializable
    {
        [Inject] private readonly RemoveTraumasUseCase removeTraumasUseCase;
        [Inject(Id = "PhysicTraumaButton")] private readonly ButtonIcon physicTraumaButton;
        [Inject(Id = "MentalTraumaButton")] private readonly ButtonIcon mentalTraumaButton;

        /*******************************************************************/
        public void Initialize()
        {
            physicTraumaButton.ClickAction += (_) => removeTraumasUseCase.RemovePhysicTrauma();
            mentalTraumaButton.ClickAction += (_) => removeTraumasUseCase.RemoveMentalTrauma();
        }
    }
}