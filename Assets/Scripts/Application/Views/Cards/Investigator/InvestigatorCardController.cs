using Zenject;

namespace Arkham.Application
{
    public class InvestigatorCardController : CardController
    {
        [Inject] private readonly AddInvestigatorUseCase addInvestigatorUseCase;
        [Inject(Id = "InvestigatorsSelector")] private readonly PlaceHoldersZone placeZone;

        /*******************************************************************/
        protected override void Clicked() => addInvestigatorUseCase.Add(cardView.Id);
    }
}
