using Arkham.Model;
using System.Collections.Generic;
using Zenject;

namespace Arkham.Application
{
    public class DataContextService
    {
        [Inject] private readonly JsonNewtonsoftService serializer;
        [Inject] private readonly DataMapperService mapper;
        [Inject] private readonly GameFiles gameFiles;
        [Inject] private readonly CardRepository cardRepository;

        /*******************************************************************/
        public void LoadDataCards()
        {
            List<CardInfo> cards = serializer.CreateDataFromResources<List<CardInfo>>(gameFiles.CardsDataFilePath);
            cardRepository.CreateWith(cards);
        }

        public void SaveProgress() => serializer.SaveFileFromData(mapper.CreateDTO(), gameFiles.PlayerProgressFilePath);

        public void LoadProgress(StartGame gameType)
        {
            FullDTO repositoryDTO = gameType == StartGame.New ? LoadNewGame() : LoadContinue();
            mapper.MapCampaigns(repositoryDTO.CampaignsList, repositoryDTO.CurrentScenario);
            mapper.MapInvestigator(repositoryDTO.InvestigatorsList);
            mapper.MapSelector(repositoryDTO.InvestigatorsSelectedList);
            mapper.MapUnlockCards(repositoryDTO.UnlockCards);
        }

        private FullDTO LoadNewGame() => serializer.CreateDataFromResources<FullDTO>(gameFiles.PlayerProgressDefaultFilePath);

        private FullDTO LoadContinue() => serializer.CreateDataFromFile<FullDTO>(gameFiles.PlayerProgressFilePath);
    }
}
