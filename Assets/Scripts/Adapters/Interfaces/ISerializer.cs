namespace Arkham.Adapters
{
    public interface ISerializer
    {
        T CreateDataFromFile<T>(string pathAndNameJsonFile);
        void SaveFileFromData(object data, string pathAndNameJsonFile);
    }
}
