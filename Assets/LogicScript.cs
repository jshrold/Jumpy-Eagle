using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public TMP_Text scoreText;
    public GameObject gameOverScreen;
    public GameObject quitConfirmScreen;   // new

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (quitConfirmScreen.activeSelf)
                cancelQuit();
            else
                openQuitConfirm();
        }
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void restartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void openQuitConfirm()
    {
        quitConfirmScreen.SetActive(true);
        Time.timeScale = 0f;               // pauses the game while the panel is open
    }

    public void cancelQuit()
    {
        quitConfirmScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    public void quitGame()
    {
        Time.timeScale = 1f;
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}