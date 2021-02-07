using Arkham.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkham.UseCases
{
    public class InvestigatorSelector : IInvestigatorSelector
    {
        private readonly Repository allData;
        private List<string> SelectorList => allData.InvestigatorsSelectedList;
        private int FirstSelectorVoid => SelectorList.FindIndex(s => IsStringEmpty(s));

        /*******************************************************************/
        public InvestigatorSelector(Repository allData)
        {
            this.allData = allData;
        }

        /*******************************************************************/
        public void AddInvestigator(string idInvestigator)
        {
            SelectorList[FirstSelectorVoid] = idInvestigator;
        }

        public void RemoveInvestigator(int selectorPosition)
        {
            SelectorList[selectorPosition] = string.Empty;
            ReorderSelector();
        }

        private void ReorderSelector()
        {
            for (int i = 0; i < SelectorList.Count - 1; i++)
            {
                if (IsStringEmpty(SelectorList[i]))
                {
                    SelectorList[i] = SelectorList[i + 1];
                    SelectorList[i + 1] = string.Empty;
                }
            }
        }

        private bool IsStringEmpty(string _string) => _string.Length == 0;
    }
}
