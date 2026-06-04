using UnityEngine;
using UnityEngine.SceneManagement;

public class ScnenesManager : MonoBehaviour
{
    public void LoadThisScene()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
}
