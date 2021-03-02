using Arkham.Entities;
using System.Collections.Generic;

namespace Arkham.Repositories
{
    public interface ICardInfoRepository
    {
        List<CardInfo> CardInfoList { get; set; }
    }
}
