using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private AudioClip musicClip;
    private AudioSource _musicSource;

    private List<AudioSource> _soundEffectSources = new List<AudioSource>();
    
    void Start()
    {
        InitiateMusic();
    }

    private void InitiateMusic()
    {
        _musicSource = gameObject.AddComponent<AudioSource>();
        _musicSource.clip = musicClip;
        _musicSource.loop = true;
        _musicSource.Play();
    }

    public void PlaySoundEffect(AudioClip clipToPlay, Vector3 position)
    {
        AudioSource soundSource = GetAvailableSoundEffectSource();
        soundSource.PlayOneShot(clipToPlay);
    }

    private AudioSource GetAvailableSoundEffectSource()
    {
        foreach (AudioSource soundEffectSource in _soundEffectSources)
        {
            if (!soundEffectSource.isPlaying)
            {
                return soundEffectSource;
            }
        }
        
        AudioSource newAudioSource = gameObject.AddComponent<AudioSource>();
        _soundEffectSources.Add(newAudioSource);
        return newAudioSource;
    }
}
