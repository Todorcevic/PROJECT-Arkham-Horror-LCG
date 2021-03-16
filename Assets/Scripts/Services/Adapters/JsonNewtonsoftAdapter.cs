using UnityEngine;
using Newtonsoft.Json;
using System.IO;

namespace Arkham.Services
{
    public class JsonNewtonsoftAdapter : ISerializer
    {
        private readonly JsonSerializerSettings serializerSettings = new JsonSerializerSettings
        {
            ObjectCreationHandling = ObjectCreationHandling.Replace
        };

        /*******************************************************************/
        public T CreateDataFromResources<T>(string pathAndNameJsonFile)
        {
            TextAsset jsonData = Resources.Load<TextAsset>(pathAndNameJsonFile);
            return JsonConvert.DeserializeObject<T>(jsonData.text);
        }

        public T CreateDataFromFile<T>(string pathAndNameJsonFile)
        {
            string jsonData = File.ReadAllText(pathAndNameJsonFile);
            return JsonConvert.DeserializeObject<T>(jsonData);
        }

        public void SaveFileFromData(object data, string pathAndNameJsonFile)
        {
            string jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(pathAndNameJsonFile, jsonData);
        }

        public void UpdateDataFromResources(string pathAndNameJsonFile, object objectToUpdate)
        {
            TextAsset jsonData = Resources.Load<TextAsset>(pathAndNameJsonFile);
            JsonConvert.PopulateObject(jsonData.text, objectToUpdate, serializerSettings);
        }

        public void UpdateDataFromFile(string pathAndNameJsonFile, object objectToUpdate)
        {
            string jsonData = File.ReadAllText(pathAndNameJsonFile);
            JsonConvert.PopulateObject(jsonData, objectToUpdate, serializerSettings);
        }
    }
}
