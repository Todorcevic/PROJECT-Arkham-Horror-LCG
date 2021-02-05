using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Controllers
{
    public interface IFullController<in T> : IClickController<T>, IHoverController<T> { }
}
