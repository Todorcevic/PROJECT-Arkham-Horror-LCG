using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Repositories
{
    public interface IContext
    {
        void LoadDataCards();
        void SaveProgress();
        void LoadProgress();
    }
}
