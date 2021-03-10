using Arkham.Entities;
using Arkham.Repositories;
using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace Arkham.Interactors
{
    public class CampaignInteractor : ICampaignInteractor
    {
        [Inject] private readonly ICampaignRepository campaignRepository;

        public IEnumerable<string> CampaignsList => campaignRepository.CampaignsList.Select(c => c.Id);

        /*******************************************************************/
        public string GetState(string campaignId) => campaignRepository.GetCampaign(campaignId).State;
    }
}
