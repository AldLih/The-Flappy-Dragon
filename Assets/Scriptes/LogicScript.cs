using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LogicScript : MonoBehaviour
{

    [SerializeField] private string sceneName;
    [SerializeField] private SoundScript soundScript;
    [SerializeField] private UIScript uiScript;


    private int bestScore;
    private int playerScore;


    private void Start()
    {
        LoadData();
    }

    IEnumerator LoadSceneAfterSound(string scene)
    {
        yield return new WaitForSeconds(soundScript.buttonClick.length); 
        SceneManager.LoadScene(scene);
    }

    IEnumerator QuitGameAfterSound()
    {
        yield return new WaitForSeconds(soundScript.buttonClick.length);
        Application.Quit();
    }
    public void SaveData()
    {
        uiScript.TheBestScoreInGame(bestScore, playerScore);
        if (playerScore > bestScore)
        {
            bestScore = playerScore;
        }
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
        soundScript.ButtonSound();
        StartCoroutine(LoadSceneAfterSound("MenuScene"));
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
        StartCoroutine(LoadSceneAfterSound("GameScene"));
    }
    public void StartGame()
    {
        Time.timeScale = 1;
        soundScript.ButtonSound();
        StartCoroutine(LoadSceneAfterSound(sceneName));
    }
    public void GoToMenu()
    {
        Time.timeScale = 1;
        soundScript.ButtonSound();
        StartCoroutine(LoadSceneAfterSound(sceneName));
    }
    public void QuitGame()
    {
        soundScript.ButtonSound();
        StartCoroutine(QuitGameAfterSound());
    }
    public void GameOver()
    {
        Time.timeScale = 1;
        SaveData();
        uiScript.ShowGameOver();
        soundScript.GameOverSound();
    }


}
