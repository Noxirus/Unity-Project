using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RefSettingsManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI volumeText;
    [SerializeField] private Slider volumeSlider;
    
    private const string MasterVolumeKey = "MasterVolume";
    private const string DifficultyKey = "GameDifficulty";

    private float currentVolume;

    private void Start()
    {
        LoadSettings();
        volumeText.text =  "Volume: " + currentVolume.ToString();
        volumeSlider.value = currentVolume;
    }

    public void UpdateVolume()
    {
        currentVolume = volumeSlider.value;
        volumeText.text = "Volume: " + currentVolume.ToString();
    }

    public void ApplySettings()
    {
        SaveSettings(currentVolume, 1);
    }
    
    public void SaveSettings(float volume, int difficulty)
    {
        PlayerPrefs.SetFloat(MasterVolumeKey, volume);
        PlayerPrefs.SetInt(DifficultyKey, difficulty);
        PlayerPrefs.Save(); // Writes changes to disk
    }

    public void LoadSettings()
    {
        float volume = PlayerPrefs.GetFloat(MasterVolumeKey, 1.0f);
        int difficulty = PlayerPrefs.GetInt(DifficultyKey, 1);
        // Apply these settings to the game
        
        currentVolume = volume;
    }
}
