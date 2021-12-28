using UnityEngine;
using Zenject;

namespace Arkham.Application.Gameplay
{
    public class Loader : MonoBehaviour
    {
        [Inject] private readonly DataMapperService dataMapper;

        /*******************************************************************/
        private void Awake()
        {
            dataMapper.MapZones();
        }
    }
}
