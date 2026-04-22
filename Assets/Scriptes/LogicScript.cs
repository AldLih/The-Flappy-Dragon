using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;


public class LogicScript : MonoBehaviour
{

    [SerializeField] private string sceneName;
    [SerializeField] private SoundScript soundScript;
    [SerializeField] private UIScript uiScript;
    [SerializeField] private Dragon dragon;

    public int scoreMultiplier = 1;
    private int bestScore;
    public int  playerScore { get; private set; } = 0;

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
        playerScore = playerScore + (normalScore*scoreMultiplier);
        uiScript.UpdateScore(playerScore, scoreMultiplier);
        if (!dragon.isDashing) 
        {
            IncreaseDifficulty();
        }
    }

    public void IncreaseDifficulty()
    {

        float baseSpawnRate = 2.5f;
        float step = 0.05f;
        float level = (playerScore / 5);
        float newSpeed = 10f + level * 2f;
        if (Pipespawner.Instance.maxSpeed < newSpeed)
        {
            newSpeed = Pipespawner.Instance.maxSpeed;
        }
        Pipespawner.Instance.spawnRate = baseSpawnRate - level * step;
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

    public void X2Button()
    {
        dragon.x2 = true;
    }
    public void DashButton()
    {
        dragon.dash = true;
    }
    public void GameOver()
    {
        Time.timeScale = 1;
        SaveData();
        uiScript.ShowGameOver();
        soundScript.GameOverSound();
    }


}
