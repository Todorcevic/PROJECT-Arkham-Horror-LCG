using Arkham.Controllers;
using Arkham.Views;
using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Components
{
    public interface IImagesCard
    {
        List<Sprite> CardImagesEN { get; }
        List<Sprite> CardImagesES { get; }
    }
}
