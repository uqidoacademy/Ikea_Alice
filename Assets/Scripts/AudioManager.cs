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
