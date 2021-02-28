namespace Arkham.Services
{
    public interface ISerializer
    {
        T CreateDataFromResources<T>(string pathAndNameJsonFile);
        T CreateDataFromFile<T>(string pathAndNameJsonFile);
        void SaveFileFromData(object data, string pathAndNameJsonFile);
        void UpdateDataFromResources(string pathAndNameJsonFile, object objectoToUpdate);
        void UpdateDataFromFile(string pathAndNameJsonFile, object objectoToUpdate);
    }
}
