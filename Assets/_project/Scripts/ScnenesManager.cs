using UnityEngine;
using UnityEngine.SceneManagement;

public class ScnenesManager : MonoBehaviour
{
    public void LoadThisScene()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    public void ChangeScene(string sceneName)
    {
        //use scene name or scene index
        SceneManager.LoadSceneAsync(sceneName);
    }
}
