using Arkham.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkham.UseCases
{
    public class DeselectInvestigator
    {
        private readonly Repository allData;
        private List<string> SelectorList => allData.InvestigatorsSelectedList;
        private int GetPositionLastInvestigator => SelectorList.IndexOf(SelectorList.FindLast(s => !s.Contains(string.Empty)));
        private string LastInvestigator => SelectorList[GetPositionLastInvestigator];

        public DeselectInvestigator(Repository allData)
        {
            this.allData = allData;
        }

        public void Deselect(int selectorPosition)
        {
            SelectorList[selectorPosition] = string.Empty;
            ReorderSelector();
        }

        private void ReorderSelector()
        {
            for (int i = 0; i < SelectorList.Count - 1; i++)
            {
                if (SelectorList[i].Contains(string.Empty))
                {
                    SelectorList[i] = SelectorList[i + 1];
                    SelectorList[i + 1] = string.Empty;
                }
            }
        }
    }
}
