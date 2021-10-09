using Zenject;

namespace Arkham.Application
{

    public class TraumasController : IInitializable
    {
        [Inject] private readonly RemoveTraumasUseCase removePhysicTraumaUseCase;
        [Inject(Id = "PhysicTraumaButton")] private readonly ButtonIcon physicTraumaButton;
        [Inject(Id = "MentalTraumaButton")] private readonly ButtonIcon mentalTraumaButton;

        /*******************************************************************/
        public void Initialize()
        {
            physicTraumaButton.ClickAction += (_) => removePhysicTraumaUseCase.RemovePhysicTrauma();
            mentalTraumaButton.ClickAction += (_) => removePhysicTraumaUseCase.RemoveMentalTrauma();
        }
    }
}