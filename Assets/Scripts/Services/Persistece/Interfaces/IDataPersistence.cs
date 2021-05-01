using Arkham.Config;

namespace Arkham.Services
{
    public interface IDataPersistence
    {
        void LoadSettings();
        void LoadDataCards();
        void LoadProgress(StartGame gameType);
        void SaveProgress();

    }
}
