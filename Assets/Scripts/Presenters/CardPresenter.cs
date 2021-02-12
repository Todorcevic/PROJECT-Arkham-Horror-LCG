using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arkham.Repositories;
using Zenject;
using UniRx;
using UnityEngine;

namespace Arkham.Presenters
{
    public class CardPresenter
    {
        [Inject] ISelectorRepository selectorRepository;
        public ReactiveCollection<List<string>> InvestigatorsSelectedList = new ReactiveCollection<List<string>>();
        public ReactiveProperty<int> player = new ReactiveProperty<int>();
        public void Init()
        {
            player.Value = 5;
            //selectorRepository.ObserveEveryValueChanged(c => c.InvestigatorsSelectedList)
            //    .Select(c => c)
            //    .Subscribe(_ => Debug.Log("dasd"));
        }
    }
}
