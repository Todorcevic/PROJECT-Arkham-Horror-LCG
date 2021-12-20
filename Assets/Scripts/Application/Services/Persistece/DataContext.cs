using Arkham.Model;
using System.Collections.Generic;
using Zenject;

namespace Arkham.Application
{
    public class DataContext
    {
        [Inject] private readonly JsonNewtonsoftAdapter serializer;
        [Inject] private readonly DataMapper mapper;
        [Inject] private readonly GameFiles gameFiles;
        [Inject] private readonly CardRepository cardRepository;

        /*******************************************************************/
        public void LoadDataCards()
        {
            List<Card> cards = serializer.CreateDataFromResources<List<Card>>(gameFiles.CardsDataFilePath);
            cardRepository.CreateWith(cards);
        }

        public void SaveProgress() => serializer.SaveFileFromData(mapper.CreateDTO(), gameFiles.PlayerProgressFilePath);

        public void LoadProgress(StartGame gameType)
        {
            FullDTO repositoryDTO = gameType == StartGame.New ? LoadNewGame() : LoadContinue();
            mapper.MapCampaigns(repositoryDTO);
            mapper.MapInvestigator(repositoryDTO);
            mapper.MapSelector(repositoryDTO);
            mapper.MapUnlockCards(repositoryDTO);
        }

        private FullDTO LoadNewGame() => serializer.CreateDataFromResources<FullDTO>(gameFiles.PlayerProgressDefaultFilePath);

        private FullDTO LoadContinue() => serializer.CreateDataFromFile<FullDTO>(gameFiles.PlayerProgressFilePath);
    }
}
