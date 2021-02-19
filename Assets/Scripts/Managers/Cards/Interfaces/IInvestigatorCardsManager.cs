using Arkham.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Arkham.Managers
{
    public interface IInvestigatorCardsManager
    {
        Transform Zone { get; }
        Dictionary<string, IInvestigatorCardView> AllInvestigatorCards { get; }
        List<IInvestigatorCardView> InvestigatorCardsList { get; }
        Sprite GetSpriteCard(string id);
    }
}
