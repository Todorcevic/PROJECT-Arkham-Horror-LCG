using Arkham.Entities;
using Arkham.Repositories;
using Zenject;

namespace Arkham.Interactors
{
    public class CardInfoInteractor : ICardInfoInteractor
    {
        [Inject] private readonly ICardInfoRepository cardInfoRepository;

        /*******************************************************************/
        public string GetRealName(string id) => cardInfoRepository.GetCardInfo(id).Real_name;
        public int GetQuantity(string id) => cardInfoRepository.GetCardInfo(id).Quantity ?? 0;
        public int GetXp(string id) => cardInfoRepository.GetCardInfo(id).Xp ?? 0;
    }
}
