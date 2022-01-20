using UnityEngine.SceneManagement;

namespace Arkham.Application
{
    public class SceneLoaderService
    {
        public void LoadScene(string sceneId) => SceneManager.LoadScene(sceneId);

    }
}
