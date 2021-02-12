using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkham.UseCases
{
    public interface IShowCard
    {
        bool IsInvestigatorEnable(string cardId);
    }
}
