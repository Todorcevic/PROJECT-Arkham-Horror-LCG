using Arkham.Entities;
using Arkham.Repositories;
using Zenject;

namespace Arkham.Interactors
{
    public class CardInfoInteractor : ICardInfoInteractor
    {
        [Inject] private readonly ICardInfoRepository cardInfoRepository;

        /*******************************************************************/
        public string GetRealName(string id) => GetCardInfo(id).Real_name;
        public int GetQuantity(string id) => GetCardInfo(id).Quantity ?? 0;
        private CardInfo GetCardInfo(string id) => cardInfoRepository.CardInfoList.Find(cardInfo => cardInfo.Code == id);
    }
}
