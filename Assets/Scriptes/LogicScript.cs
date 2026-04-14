using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text score;
    public GameObject gameOver;
    [SerializeField] private string sceneName;
   

    public AudioSource music;
    [SerializeField] private AudioClip deathSound;
    private AudioSource audioSource;



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
        audioSource.PlayOneShot(deathSound);
        music.Stop();
    }


}
