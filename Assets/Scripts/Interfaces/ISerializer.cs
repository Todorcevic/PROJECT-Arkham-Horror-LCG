using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkham.UI
{
    public interface ISerializer
    {
        T CreateDataFromFile<T>(string pathAndNameJsonFile);
        void SaveFileFromData(object data, string pathAndNameJsonFile);
    }
}
