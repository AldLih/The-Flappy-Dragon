using UnityEngine;
using UnityEngine.Audio;

public class SoundScript : MonoBehaviour
{

    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioClip buttonClick;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip music;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip scoreSound;
 

    private void Start()
    {
        bool sfxActive = PlayerPrefs.GetInt("SFX_Enabled", 1) == 1;
        bool musicActive = PlayerPrefs.GetInt("Music_Enabled", 1) == 1;

        sfxSource.mute = !sfxActive;
        musicSource.mute = !musicActive;
    }
    public void ButtonSound()
    {
        sfxSource.PlayOneShot(buttonClick);
    }

    public void GameOverSound()
    {
        sfxSource.PlayOneShot(deathSound);
        musicSource.Stop();
    }
    public void JumpSound()
    {
        sfxSource.PlayOneShot(jumpSound);
    }

    public void ScoreSound()
    {
        sfxSource.PlayOneShot(scoreSound);

    }

}
