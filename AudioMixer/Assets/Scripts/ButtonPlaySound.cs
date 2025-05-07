using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource), typeof(Button))]
public class ButtonPlaySound : MonoBehaviour
{
    private AudioSource _audioSource;
    private Button _button;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();

        _button = GetComponent<Button>();
        _button.onClick.AddListener(PlaySound);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(PlaySound);
    }

    private void PlaySound()
    {
        _audioSource.Play();
    }
}
