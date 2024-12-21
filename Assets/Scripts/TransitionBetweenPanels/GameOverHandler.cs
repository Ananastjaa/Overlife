using UnityEngine;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;
    public void GameOver()
    {
        Time.timeScale = 0;
        _gameOverPanel.SetActive(true);
    }
}