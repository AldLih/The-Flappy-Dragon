using UnityEngine;
using UnityEngine.SceneManagement;


public class LogicScript : MonoBehaviour
{

    [SerializeField] private string sceneName;
    [SerializeField] private SoundScript soundScript;
    [SerializeField] private UIScript uiScript;


    private int bestScore = 0;
    private int playerScore;


    private void Start()
    {
        LoadData();
    }
    public void SaveData()
    {
        uiScript.TheBestScoreInGame(bestScore);
        PlayerPrefs.SetInt("BestScore", bestScore);
        PlayerPrefs.Save();

    }

    public void LoadData()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", bestScore);
        uiScript.TheBestScoreInMenu(bestScore);
    }

    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }

    public void AddScore(int normalScore)
    {
        playerScore += normalScore;
        uiScript.ScoreChange(playerScore);
        IncreaseDifficulty();
    }

    public void IncreaseDifficulty()
    {

        float newSpeed = 10f + (playerScore / 5) * 2f;
        if (Pipespawner.Instance.maxSpeed < newSpeed)
        {
            newSpeed = Pipespawner.Instance.maxSpeed;
        }
        Pipespawner.Instance.spawnRate = 30f / newSpeed;
        Pipespawner.Instance.moveSpeed = newSpeed;
    }

    public void PauseGame()
    {
        uiScript.ShowPauseMenu();
        soundScript.ButtonSound();
        Time.timeScale = 0;
    }

    public void ContinueGame()
    {
        uiScript.ClosePauseMenu();
        soundScript.ButtonSound();
        Time.timeScale = 1;
    }
    public void RestartGame()
    {
        Time.timeScale = 1;
        soundScript.ButtonSound();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame()
    {
        Time.timeScale = 1;
        soundScript.ButtonSound();
        SceneManager.LoadScene(sceneName);
    }
    public void GoToMenu()
    {
        Time.timeScale = 1;
        soundScript.ButtonSound();
        SceneManager.LoadScene(sceneName);
    }
    public void QuitGame()
    {
        soundScript.ButtonSound();
        Application.Quit();
    }
    public void GameOver()
    {
        Time.timeScale = 1;
        uiScript.ShowGameOver();
        SaveData();
        soundScript.GameOverSound();
    }


}
