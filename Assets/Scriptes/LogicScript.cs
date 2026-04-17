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




    public AudioSource music;
    [SerializeField] private AudioClip deathSound;
    private AudioSource audioSource;
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



    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void AddScore(int normalScore)
    {
        playerScore += normalScore;
        score.text = playerScore.ToString();
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(sceneName);
    }
    public void GameOver()
    {

        gameOver.SetActive(true);
        SaveData();
        audioSource.PlayOneShot(deathSound);
        music.Stop();
    }


}
