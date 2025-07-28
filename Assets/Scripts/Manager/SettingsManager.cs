using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [Header("Settings UI")]
    [SerializeField] private TextMeshProUGUI volumeText;
    [SerializeField] private Slider volumeSlider;
    
    private int _currentVolume;
    private const string VolumeKey = "Volume";
    
    void Start()
    {
        volumeSlider.onValueChanged.AddListener(UpdateVolume);
        
        LoadSettings();
        volumeText.text = "Volume: " + _currentVolume;
        volumeSlider.value = _currentVolume;
    }

    private void UpdateVolume(float volume)
    {
        _currentVolume = (int)volume;
        volumeText.text = "Volume: " + _currentVolume;
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetInt(VolumeKey, _currentVolume);
        PlayerPrefs.Save();
    }

    public void StartGame()
    {
        LevelManager.Instance.LoadLevel("KrakenScene");
    }

    private void LoadSettings()
    {
        _currentVolume = PlayerPrefs.GetInt(VolumeKey);
    }
}
