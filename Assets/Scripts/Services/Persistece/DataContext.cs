using Arkham.Config;
using Arkham.Model;
using System.Collections.Generic;
using Zenject;

namespace Arkham.Services
{
    public class DataContext : IDataPersistence
    {
        [Inject] private readonly ISerializer serializer;
        [Inject] private readonly IMapper mapper;
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
