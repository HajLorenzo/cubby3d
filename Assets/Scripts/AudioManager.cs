using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    public static AudioManager Instance => _instance;
    [SerializeField] private SoundEffect soundEffect;
    private AudioSource audioSource;

    private void Awake()
    {
        _instance = this;
        audioSource = GetComponent<AudioSource>();
    }
    public void Play(int id)
    {
        audioSource.clip = soundEffect.audios[id];
        audioSource.Play();
    }
}
