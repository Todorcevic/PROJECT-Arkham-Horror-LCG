using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Services
{
    public interface IDataPersistence
    {
        void LoadDataCards();
        void SaveProgress();
        void LoadProgress();
        void NewGame();
        bool CanContineGame();
    }
}
