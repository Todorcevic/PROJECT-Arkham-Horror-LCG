namespace Arkham.Services
{
    public interface IMapper
    {
        FullDTO CreateDTO();
        void MapUnlockCards(FullDTO repositoryDTO);
        void MapSelector(FullDTO repositoryDTO);
        void MapInvestigator(FullDTO repositoryDTO);
        void MapCampaigns(FullDTO repositoryDTO);
    }
}
