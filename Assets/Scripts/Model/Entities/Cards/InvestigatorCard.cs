using Zenject;

namespace Arkham.Model
{
    public class InvestigatorCard : Card
    {
        [Inject] private readonly InvestigatorsRepository investigatorsRepository;

        private Investigator InvestigatorData => investigatorsRepository.Get(Id);

        /*******************************************************************/

    }
}
