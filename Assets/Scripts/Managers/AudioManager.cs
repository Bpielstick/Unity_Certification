using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.Log("Audio Manager = Null");

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] AudioClip[] _audioClips;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _audioClips[0];
        _audioSource.loop = true;
        _audioSource.Play();
    }

    public void PlaySound(int clipIndex)
    {
        _audioSource.PlayOneShot(_audioClips[clipIndex]);
    }

    public void StopAudio()
    {
        _audioSource.Pause();
    }

    public void StartAudio()
    {
        _audioSource.UnPause();
    }
}
