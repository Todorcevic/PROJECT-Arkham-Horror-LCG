using Arkham.Entities;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System;
using Arkham.Repositories;
using Zenject;

namespace Arkham.Interactors
{
    public class CardInfoInteractor : ICardInfoInteractor
    {
        [Inject] private readonly ICardInfoRepository cardInfoRepository;

        /*******************************************************************/
        public CardInfo GetCardInfo(string id) => cardInfoRepository.CardInfoList.Find(cardInfo => cardInfo.Code == id);
    }
}
