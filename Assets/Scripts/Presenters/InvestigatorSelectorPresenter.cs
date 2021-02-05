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
        public void CreateReactiveViewModel(IInvestigatorSelectorView investigatorSelectorView)
        {
            allData.InvestigatorsSelectedList.ObserveEveryValueChanged(invSelectedList => invSelectedList[investigatorSelectorView.Id])
                .Subscribe(investigatorId =>
                {



                    Sprite sprite = null;
                    if (investigatorId != string.Empty)
                        sprite = cardRepository.GetCardView(investigatorId).GetCardImage();
                    investigatorSelectorView.ChangeImage(sprite);
                }
                );
        }
    }
}
