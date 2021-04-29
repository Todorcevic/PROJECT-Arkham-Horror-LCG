namespace Arkham.Services
{
    public interface IDataContext
    {
        void LoadDataCards();
        void SaveProgress();
        void LoadSettings();
    }
}
