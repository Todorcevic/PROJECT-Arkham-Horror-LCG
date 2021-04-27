using Arkham.Entities;
using System.Collections.Generic;

namespace Arkham.Repositories
{
    public interface ICardInfoLoader
    {
        List<CardInfo> CardInfoList { set; }
    }
}
