using UnityEngine;
using Arkham.Views;
using Arkham.Managers;
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
                .Select(investigatorId => GetSprite(investigatorId))
                .Subscribe(sprite => investigatorSelectorView.ChangeImage(sprite));
        }

        private Sprite GetSprite(string investigatorId)
        {
            if (investigatorId != string.Empty)
                return cardRepository.GetCardView(investigatorId).GetCardImage();
            return null;
        }
    }
}
