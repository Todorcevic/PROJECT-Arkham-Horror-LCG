using Arkham.Models;
using System.Collections.Generic;

namespace Arkham.Repositories
{
    public interface ICardInfoRepository
    {
        List<CardInfo> CardInfoList { get; set; }
    }
}
