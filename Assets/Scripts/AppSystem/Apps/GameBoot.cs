using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBoot : MonoBehaviour
{
    public Scene gameScene;
    
    public void BootGame()
    {
        SceneManager.LoadSceneAsync(gameScene.path ,LoadSceneMode.Additive);
    }

    public void ExitGame()
    {
        SceneManager.UnloadSceneAsync(gameScene);
    }
}
