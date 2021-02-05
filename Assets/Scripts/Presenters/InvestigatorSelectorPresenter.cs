using UnityEngine;
using Arkham.Views;
using Arkham.Models;
using Arkham.Repositories;
using UniRx;

namespace Arkham.Presenters
{
    public class InvestigatorSelectorPresenter : IPresenter<IInvestigatorSelectorView>
    {
        private readonly Repository allData;
        private readonly CardRepository cardRepository;

        /*******************************************************************/
        public InvestigatorSelectorPresenter(Repository allData, CardRepository cardRepository)
        {
            this.allData = allData;
            this.cardRepository = cardRepository;
        }

        /*******************************************************************/
        void IPresenter<IInvestigatorSelectorView>.CreateReactiveViewModel(IInvestigatorSelectorView investigatorSelectorView)
        {
            InvestigatorSelector investigatorSelector = allData.AllInvestigatorSelectors[investigatorSelectorView.Id];
            investigatorSelector.ObserveEveryValueChanged(i => i.InvestigatorId)
                .Subscribe(investigatorId =>
                {
                    Sprite sprite = null;
                    if (investigatorId != string.Empty)
                        sprite = cardRepository.AllCards[investigatorId].GetCardImage();
                    investigatorSelectorView.ChangeImage(sprite);
                });
        }
    }
}
