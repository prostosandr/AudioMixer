using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonMute : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixerGroup;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ToggleMute);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(ToggleMute);
    }

    private void ToggleMute()
    {
        float minVolume = -80f;
        float maxVolume = 0f;

        _mixerGroup.audioMixer.GetFloat(_mixerGroup.name, out float currentVolume);

        bool isMuted = currentVolume <= minVolume;

        _mixerGroup.audioMixer.SetFloat(_mixerGroup.name, isMuted ? maxVolume : minVolume);
    }
}
