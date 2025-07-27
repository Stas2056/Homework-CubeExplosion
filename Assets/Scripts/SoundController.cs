using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private ClickTrigger _clickTrigger;
    [SerializeField] private AudioSource _audioSource;

    private void OnEnable()
    {
        _clickTrigger.�licked += PlaySound;
    }

    private void OnDisable()
    {
        _clickTrigger.�licked -= PlaySound;
    }

    private void PlaySound()
    {
        Debug.Log("sound");
        _audioSource.Play();
    }
}