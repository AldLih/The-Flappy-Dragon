using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text score;
    public GameObject gameOver;
    [SerializeField] private string sceneName;
    [SerializeField] private TextMeshProUGUI recordText;
    [SerializeField] private TextMeshProUGUI recordTextInMenu;
    [SerializeField] private TextMeshProUGUI currentTextInMenu;
    [SerializeField] private SoundScript soundScript;

    int bestScore = 0;


    private void Start()
    {
        LoadData();
    }
    public void SaveData()
    {
        if (int.Parse(score.text) > bestScore) {
            bestScore = int.Parse(score.text);
            PlayerPrefs.SetInt("BestScore", bestScore);
            recordText.text = $"NEW RECORD : {bestScore}";
            PlayerPrefs.Save();
        }

        else
        { 
            PlayerPrefs.SetInt("BestScore", bestScore);
            recordText.text = $"The Best Score : {bestScore}";
            PlayerPrefs.Save();
        }
    }

    public void LoadData()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", bestScore);
        if (recordTextInMenu != null)
        {
            recordTextInMenu.text = $"The Best Score : {bestScore}";
        }
    }

    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }

    public void AddScore(int normalScore)
    {
        playerScore += normalScore;
        score.text = playerScore.ToString();
    }


    public void RestartGame()
    {
        soundScript.ButtonSound();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame()
    {
        soundScript.ButtonSound();
        SceneManager.LoadScene(sceneName);
    }
    public void GoToMenu()
    {
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

        if (currentTextInMenu != null)
        {
            currentTextInMenu.text = $"Current Score : {score.text}";
        }
        score.gameObject.SetActive(false);
        gameOver.SetActive(true);
        SaveData();
        soundScript.GameOverSound();
    }


}
