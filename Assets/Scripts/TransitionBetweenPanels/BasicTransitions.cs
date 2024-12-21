using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicTransitions : MonoBehaviour
{
    // here will be other button script like homeButt, shopButt, continueButt, PauseButt, ...

    public void RestartButtonPressed()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        Time.timeScale = 1;
    }
}
