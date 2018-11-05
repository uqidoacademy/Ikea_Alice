using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    /*#region Singleton

    private AudioManager()
    {
        // Prevent outside instantiation
    }

    private static readonly AudioManager _singleton = new AudioManager();
    public static AudioManager Instance
    {
        get { return _singleton; }
    }

    #endregion*/

    [SerializeField]
    private AudioClip AmbientSound;
    [SerializeField]
    private AudioClip AmbientNoiseSound;
    [SerializeField]
    private AudioSource RoomAudioSource;
    [SerializeField]
    private AudioSource RoomNoiseSource;
    [SerializeField]
    private AudioSource AudioSourceWonderland;
    [SerializeField]
    private float VolumeReducerScale = 1;
    
    private float initialAmbientVolume = 1;
    private float initialNoiseVolume = 1;

    private void Start()
    {
        RoomAudioSource.clip = AmbientSound;
        initialAmbientVolume = RoomAudioSource.volume;
        RoomAudioSource.Play();

        RoomNoiseSource.clip = AmbientNoiseSound;
        initialNoiseVolume = RoomNoiseSource.volume;
        RoomNoiseSource.Play();
    }

    public void PlayWonderland()
    {
        StartCoroutine(AudioManager.FadeOut(RoomAudioSource, 0.5f));
        StartCoroutine(AudioManager.FadeIn(AudioSourceWonderland, 0.5f));
    }

    public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }

    public static IEnumerator FadeIn(AudioSource audioSource, float FadeTime)
    {
        float targetVolume = audioSource.volume;
        audioSource.volume = 0;
        audioSource.Play();
        while (audioSource.volume < targetVolume)
        {
            audioSource.volume += targetVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        
        audioSource.volume = targetVolume;
    }

    public void playEffectOnce(AudioSource source)
    {
        if (source != null)
        {
            //RoomAudioSource.volume = initialAmbientVolume * VolumeReducerScale;
            //RoomNoiseSource.volume = initialNoiseVolume * VolumeReducerScale;
            source.Play();
        }
    }
}
