using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicTransitions : MonoBehaviour
{
    // here will be other button script like homeButt, shopButt, continueButt, PauseButt, ...
    [SerializeField] private GameObject _shopPanel;

    public void RestartButtonPressed()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        Time.timeScale = 1;
    }

    public void ShopButtonPressed()
    {
        _shopPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseShopButtonPressed()
    {
        _shopPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
