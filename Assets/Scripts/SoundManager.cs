using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    // Background music
    public AudioClip backgroundMusic;
    private AudioSource backgroundMusicSource;
    [Range(0f, 1f)] public float backgroundMusicVolume = 1f;


    // Button click sound
    public AudioClip buttonClickSound;
    private AudioSource buttonClickSoundSource;
    [Range(0f, 1f)] public float buttonClickSoundVolume = 1f;

    private void Awake()
    {
        // Singleton pattern to ensure only one instance of the SoundManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Set up audio sources
        backgroundMusicSource = gameObject.AddComponent<AudioSource>();
        buttonClickSoundSource = gameObject.AddComponent<AudioSource>();

        // Set default settings
        backgroundMusicSource.loop = true;
        backgroundMusicSource.clip = backgroundMusic;
        backgroundMusicSource.volume = backgroundMusicVolume;

        buttonClickSoundSource.volume = buttonClickSoundVolume;

        // Start playing background music
        PlayBackgroundMusic();
    }

    public void PlayBackgroundMusic()
    {
        if (backgroundMusicSource != null && backgroundMusic != null && !backgroundMusicSource.isPlaying)
        {
            backgroundMusicSource.Play();
        }
    }

    public void PlayButtonClickSound()
    {
        if (buttonClickSoundSource != null && buttonClickSound != null)
        {
            buttonClickSoundSource.PlayOneShot(buttonClickSound);
        }
    }
}
