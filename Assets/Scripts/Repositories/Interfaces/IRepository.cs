using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkham.Repositories
{
    public interface IRepository : ICampaignRepository, IInvestigatorRepository, IInvestigatorSelectorRepository, ICardInfoRepository
    {
    }
}
