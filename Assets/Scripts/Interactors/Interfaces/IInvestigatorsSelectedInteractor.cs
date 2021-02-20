using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkham.Interactors
{
    public interface IInvestigatorsSelectedInteractor
    {
        void InitializeSelectors();
        void SelectInvestigator(string investigatorId);
        void AddInvestigator(string investigatorId);
        void RemoveInvestigator(string investigatorId);
    }
}
