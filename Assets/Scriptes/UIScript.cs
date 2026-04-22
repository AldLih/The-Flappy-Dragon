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
    [SerializeField] private GameObject settignsMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject confirmMenu;
    [SerializeField] private GameObject dashButton;
    [SerializeField] private GameObject x2Button;


    public void UpdateScore(int playerScore, int multiplier)
    {
        if (multiplier == 1)
        {
            score.text = playerScore.ToString();
            score.color = Color.white;
        }
        else if (multiplier == 2)
        {
            score.text = playerScore + " X 2";
            score.color = new Color32(255, 187, 0, 255);
        }
    }


    public void ChangeX2ButtonCollor(bool enable, bool active)
    {
        if (active)
        {
            x2Button.GetComponent<Image>().color = new Color(255, 187, 0);
        }
        else
        {
            if (!enable)
            {
                x2Button.GetComponent<Image>().color = new Color(75, 0, 0);
            }
            else { x2Button.GetComponent<Image>().color = new Color(255, 255, 255); }
        }
    }
    public void ChangeDashButtonCollor(bool enable)
    {
        if (!enable)
        {
            dashButton.GetComponent<Image>().color = new Color(75, 0, 0);
        }
        else { dashButton.GetComponent<Image>().color = new Color(255, 255, 255); }
    }

    public void ShowGameOver()
    {
        if (currentScore != null)
        {
            currentScore.text = $"Current Score : {logicScript.playerScore}";
        }
        pause.SetActive(false);
        score.gameObject.SetActive(false);
        gameOver.SetActive(true);
        dashButton.SetActive(false);
    }
    public void SettingsMenuView(bool enable)
    {
        settignsMenu.SetActive(enable);
    }

    public void ShowConfirmMenu()
    {
        confirmMenu.SetActive(true);
    }
    public void CloseConfirmMenu()
    {
        confirmMenu.SetActive(false);
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
    public void TheBestScoreInGame(int bestScore, int playerScore)
    {
        if (playerScore > bestScore)
        {
            recordScore.text = $"NEW RECORD : {playerScore}";
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
