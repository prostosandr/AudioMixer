using UnityEngine;
using UnityEngine.Audio;

public class AudioPanel : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private bool _isSoundsPlays;
    [SerializeField] private int logMultipler;

    public void ToggleAudio()
    {
        float minVolume = -80;
        float maxVolume = 0;


        if (_isSoundsPlays)
        {
            _mixer.audioMixer.SetFloat("MasterVolume", maxVolume);
            _isSoundsPlays = false;
        }
        else
        {
            _mixer.audioMixer.SetFloat("MasterVolume", minVolume);
            _isSoundsPlays = true;
        }
    }

    public void ChangeMasterVolume(float volume)
    {
        _mixer.audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * logMultipler);
    }

    public void ChangeMusicVolume(float volume)
    {
        _mixer.audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * logMultipler);
    }

    public void ChangeButtonsVolume(float volume)
    {
        _mixer.audioMixer.SetFloat("ButtonsVolume", Mathf.Log10(volume) * logMultipler);
    }
}
