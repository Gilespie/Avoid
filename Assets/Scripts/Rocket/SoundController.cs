using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioClip _beginSFX;
    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        BeginSound();
    }

    private void BeginSound()
    {
        _audioSource.PlayOneShot(_beginSFX);
    }
}