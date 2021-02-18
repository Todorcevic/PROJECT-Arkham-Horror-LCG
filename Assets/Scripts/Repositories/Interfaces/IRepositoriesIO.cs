using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Repositories
{
    public interface IRepositoriesIO
    {
        void LoadDataCards();
        void SaveProgress();
        void LoadProgress();
    }
}
