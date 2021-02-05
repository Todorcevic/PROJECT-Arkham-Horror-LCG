using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Arkham.Views
{
    public interface ICardView
    {
        string Id { get; set; }
        void SetCardImage(Sprite sprite);
        Sprite GetCardImage();
    }
}
