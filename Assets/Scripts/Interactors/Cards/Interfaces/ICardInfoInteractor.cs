using Arkham.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkham.Interactors
{
    public interface ICardInfoInteractor
    {
        string GetRealName(string id);
        int GetQuantity(string id);
        int GetXp(string id);
    }
}
