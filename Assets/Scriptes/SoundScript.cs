using UnityEngine;
using UnityEngine.Audio;

public class SoundScript : MonoBehaviour
{

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioClip buttonClick;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip music;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip scoreSound;


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
