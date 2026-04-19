using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    [SerializeField] private LogicScript logicScript;
    [SerializeField] private TextMeshProUGUI recordScore;
    [SerializeField] private TextMeshProUGUI recordScoreInMenu;
    [SerializeField] private TextMeshProUGUI currentScore;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private Text score;
    [SerializeField] private GameObject pause;
    [SerializeField] private GameObject pauseMenu;

    public void ScoreChange(int playerScore)
    {
        score.text = playerScore.ToString();
    }

    public void ShowGameOver()
    {
        if (currentScore != null)
        {
            currentScore.text = $"Current Score : {score.text}";
        }
        pause.SetActive(false);
        score.gameObject.SetActive(false);
        gameOver.SetActive(true);
    }
    public void ShowPauseMenu()
    {
        pauseMenu.SetActive(true);
        pause.SetActive(false);
    }
    public void ClosePauseMenu()
    {
        pauseMenu.SetActive(false);
        pause.SetActive(true);
    }

    public void TheBestScoreInMenu(int bestScore)
    {
        if (recordScoreInMenu != null)
        {
            recordScoreInMenu.text = $"The Best Score : {bestScore}";
        }
    }
    public void TheBestScoreInGame(int bestScore)
    {
        if (int.Parse(score.text) > bestScore) {
            bestScore = int.Parse(score.text);
            recordScore.text = $"NEW RECORD : {bestScore}";
        }

        else
        {
            if (recordScore != null)
            {
                recordScore.text = $"The Best Score : {bestScore}";
            }
        }

    }
}
