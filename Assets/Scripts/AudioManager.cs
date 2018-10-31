using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    [SerializeField]
    private AudioClip AmbientSound;
    [SerializeField]
    private AudioClip AmbientNoiseSound;
    [SerializeField]
    private AudioSource RoomAudioSource;
    [SerializeField]
    private AudioSource RoomNoiseSource;

    private void Start()
    {
        RoomAudioSource.clip = AmbientSound;
        RoomAudioSource.Play();

        RoomNoiseSource.clip = AmbientNoiseSound;
        RoomNoiseSource.Play();
    }
}
