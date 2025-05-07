using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderVolume : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixerGroup;
    [SerializeField] private float _logMultipler;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _slider.onValueChanged.AddListener(ChangeVolume);
    }

    private void OnDestroy()
    {
        _slider.onValueChanged.RemoveListener(ChangeVolume);
    }

    private void ChangeVolume(float volume)
    {
        float minVolume = 0.0001f;
        float mindB = -80f;
        float dB;

        if (volume > minVolume)
            dB = Mathf.Log10(volume) * _logMultipler;
        else
            dB = mindB;

        _mixerGroup.audioMixer.SetFloat(_mixerGroup.name, dB);
    }
}
