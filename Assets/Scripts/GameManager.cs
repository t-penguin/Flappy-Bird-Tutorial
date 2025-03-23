using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private GameObject _gameOverScreen;
    [field: SerializeField] public int Score { get; private set; }

    #region Monobehaviour Callbacks

    // Subscribe to events
    private void OnEnable()
    {
        EventManager.IncreasingScore += OnIncreaseScore;
        EventManager.GameOver += OnGameOver;
    }

    // Unsubscribe from events
    private void OnDisable()
    {
        EventManager.IncreasingScore -= OnIncreaseScore;
        EventManager.GameOver -= OnGameOver;
    }

    #endregion

    #region Event Callbacks

    // Called from button. Reloads the scene
    public void RestartGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    // Opens up the Game Over UI screen
    private void OnGameOver() => _gameOverScreen.SetActive(true);

    // Increases the score and updates the display
    [ContextMenu("Increase Score")]
    private void OnIncreaseScore(int amount)
    {
        Score += amount;
        _scoreText.text = Score.ToString();
    }

    #endregion
}