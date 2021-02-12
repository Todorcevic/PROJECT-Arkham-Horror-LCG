using Arkham.Repositories;
using Arkham.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Arkham.Managers
{
    public class CardsDeckManager : IDeckZone
    {
        public Dictionary<string, CardDeckView> InvestigatorsCards { get; } = new Dictionary<string, CardDeckView>();
        public List<CardDeckView> InvestigatorsListCards => InvestigatorsCards.Values.ToList();

        /*******************************************************************/
        public void Init()
        {
            foreach (CardDeckView investigatorView in InvestigatorsListCards)
                investigatorView.Controller.SwitchEnable();
        }
    }
}
