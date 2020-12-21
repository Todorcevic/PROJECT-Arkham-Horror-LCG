using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System;

namespace Arkham.Adapters
{
    public class JsonNewtonsoftAdapter : ISerializer
    {
        public T CreateDataFromFile<T>(string pathAndNameJsonFile)
        {
            TextAsset JsonFile = Resources.Load<TextAsset>(pathAndNameJsonFile);
            return JsonConvert.DeserializeObject<T>(JsonFile.text);
        }

        public void SaveFileFromData(object data, string pathAndNameJsonFile)
        {
            var jsonString = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(pathAndNameJsonFile, jsonString);
        }
    }
}
