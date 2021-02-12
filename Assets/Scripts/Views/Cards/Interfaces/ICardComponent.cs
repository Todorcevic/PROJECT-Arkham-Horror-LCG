using Arkham.Controllers;
using Arkham.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Arkham.Views
{
    public interface ICardComponent
    {
        string Id { get; }
        Sprite GetCardImage { get; }
        Transform Transform { get; }
        ICardController Controller { get; }
        CardInfo Info { get; }
        void Enable(bool isEnable);
        void Show(bool isShow);
    }
}
