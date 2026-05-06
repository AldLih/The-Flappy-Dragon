using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class MenuScript : MonoBehaviour
{
    [SerializeField] private SoundScript soundScript;
    [SerializeField] private UIScript uiScript;
    [SerializeField] private Image musicButtonImage;
    [SerializeField] private Button musicButton;
    [SerializeField] private Sprite musicOnSprite;
    [SerializeField] private Sprite musicOnSpriteHigh;
    [SerializeField] private Sprite musicOnSpritePress;
    [SerializeField] private Sprite musicOffSprite;
    [SerializeField] private Sprite musicOffSpritePress;
    [SerializeField] private Sprite musicOffSpriteHigh;
    [SerializeField] private Image sfxButtonImage;
    [SerializeField] private Button sfxButton;
    [SerializeField] private Sprite sfxOnSprite;
    [SerializeField] private Sprite sfxOnSpritePress;
    [SerializeField] private Sprite sfxOnSpriteHigh;
    [SerializeField] private Sprite sfxOffSprite;
    [SerializeField] private Sprite sfxOffSpritePress;
    [SerializeField] private Sprite sfxOffSpriteHigh;
    private bool settingsEnable = false;
    private bool confirmMenu = false;
    private bool sfxEnable = true;
    private bool musicEnable = true;

    private void Start()
    {
        sfxEnable = PlayerPrefs.GetInt("SFX_Enabled", 1) == 1;
        musicEnable = PlayerPrefs.GetInt("Music_Enabled", 1) == 1;
        UpdateMusic();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !confirmMenu)
        {
            SettingsMenu();
        }
    }

    private void UpdateMusic()
    {
        soundScript.musicSource.mute = !musicEnable;
        musicButtonImage.sprite = musicEnable ? musicOnSprite : musicOffSprite;
        soundScript.sfxSource.mute = !sfxEnable;
        sfxButtonImage.sprite = sfxEnable ? sfxOnSprite : sfxOffSprite;
        HighPressMusic(musicEnable);
        HighPressSFX(sfxEnable);
    }
    public void MusicStop()
    {
        musicEnable = !musicEnable;
        soundScript.musicSource.mute = !musicEnable;
        HighPressMusic(musicEnable);
        musicButtonImage.sprite = musicEnable ? musicOnSprite : musicOffSprite;
        PlayerPrefs.SetInt("Music_Enabled", musicEnable ? 1 : 0);
    }
    public void SFXStop()
    {
        sfxEnable = !sfxEnable;
        soundScript.sfxSource.mute = !sfxEnable;
        HighPressSFX(sfxEnable);
        sfxButtonImage.sprite = sfxEnable ? sfxOnSprite : sfxOffSprite;
        PlayerPrefs.SetInt("SFX_Enabled", sfxEnable ? 1 : 0);
    }


    public void HighPressMusic(bool enableMusic)
    {
        if (enableMusic)
        {
            musicButton.spriteState = new SpriteState
            {
                highlightedSprite = musicOnSpriteHigh,
                pressedSprite = musicOnSpritePress
            };
        }
        else
        {
            musicButton.spriteState = new SpriteState
            {
                highlightedSprite = musicOffSpriteHigh,
                pressedSprite = musicOffSpritePress
            };
        }
    }

    public void HighPressSFX(bool enableSFX)
    {
        if (enableSFX)
        {
            sfxButton.spriteState = new SpriteState
            {
                highlightedSprite = sfxOnSpriteHigh,
                pressedSprite = sfxOnSpritePress
            };
        }
        else
        {
            sfxButton.spriteState = new SpriteState
            {
                highlightedSprite = sfxOffSpriteHigh,
                pressedSprite = sfxOffSpritePress
            };
        }
    }
    public void ConfirmMenu()
    {
        uiScript.ShowConfirmMenu();
        soundScript.ButtonSound();
        confirmMenu = true;
    }
    public void ConfirmMenuClose()
    {
        uiScript.CloseConfirmMenu();
        soundScript.ButtonSound();
        confirmMenu = false;
    }
    public void SettingsMenu()
    {
        settingsEnable = !settingsEnable;
        uiScript.SettingsMenuView(settingsEnable);
        soundScript.ButtonSound();
    }
}
