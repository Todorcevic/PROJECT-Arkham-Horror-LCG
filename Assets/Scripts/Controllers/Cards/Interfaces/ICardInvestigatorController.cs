using Arkham.Models;

namespace Arkham.Controllers
{
    public interface ICardInvestigatorController : ICardController
    {
        InvestigatorInfo Investigator { get; set; }
    }
}
