using Arkham.Config;

namespace Arkham.Services
{
    public interface IDataPersistence
    {
        void LoadDataCards();
        void LoadProgress(StartGame gameType);
        void SaveProgress();
    }
}
