using TMPro;
using UnityEngine;


public class MenuScript : MonoBehaviour
{
    [SerializeField] private SoundScript soundScript;
    [SerializeField] private UIScript uiScript;
    [SerializeField] private TextMeshProUGUI sfxButton;
    [SerializeField] private TextMeshProUGUI musicButton;
    private bool settingsEnable = false;
    private bool confirmMenu = false;
    private bool sfxEnable = true;
    private bool musicEnable = true;

    private void Start()
    {
        sfxEnable = PlayerPrefs.GetInt("SFX_Enabled", 1) == 1;
        musicEnable = PlayerPrefs.GetInt("Music_Enabled", 1) == 1;
        UpdateVisuals();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !confirmMenu)
        {
            SettingsMenu();
        }
    }

    private void UpdateVisuals()
    {
        sfxButton.text = sfxEnable ? "SFX : ON" : "SFX : OFF";
        musicButton.text = musicEnable ? "Music : ON" : "Music : OFF";
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

    public void SFXStop()
    {
        sfxEnable = !sfxEnable;
        soundScript.sfxSource.mute = !sfxEnable;
        sfxButton.text = sfxEnable ? "SFX : ON" : "SFX : OFF";

        PlayerPrefs.SetInt("SFX_Enabled", sfxEnable ? 1 : 0);
    }

    public void MusicStop()
    {
        musicEnable = !musicEnable;
        soundScript.musicSource.mute = !musicEnable;
        musicButton.text = musicEnable ? "Music : ON" : "Music : OFF";

        PlayerPrefs.SetInt("Music_Enabled", musicEnable ? 1 : 0);
    }
}
