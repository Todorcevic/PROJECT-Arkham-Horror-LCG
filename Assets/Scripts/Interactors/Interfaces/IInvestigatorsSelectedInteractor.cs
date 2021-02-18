using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkham.Iterators
{
    public interface IInvestigatorsSelectedInteractor
    {
        void InitializeSelectors();
        void AddInvestigator(string investigatorId);
        void RemoveInvestigator(string investigatorId);
        int AmountInvestigators(string investigatorId);
    }
}
