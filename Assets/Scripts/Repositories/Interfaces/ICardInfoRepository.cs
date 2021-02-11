using Arkham.Models;
using System.Collections.Generic;

namespace Arkham.Repositories
{
    public interface ICardInfoRepository
    {
        Dictionary<string, CardInfo> AllCardsInfo { get; }
        List<CardInfo> CardInfoList { get; }
    }
}
