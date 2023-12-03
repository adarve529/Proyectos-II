using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private enum VolumeType
    {
        MUSIC,
        SFX
    }

    [Header("Type")]
    [SerializeField] private VolumeType volumeType;

    private Slider slider;

    private void Start()
    {
        slider = this.GetComponentInChildren<Slider>();

        switch (volumeType)
        {
            case VolumeType.MUSIC:
                slider.value = AudioManager.Instance.musicVolume;
                break;
            case VolumeType.SFX:
                slider.value = AudioManager.Instance.sfxVolume;
                break;
            default:
                Debug.LogWarning("Volume type not supported: " + volumeType);
                break;
        }
    }




    private void Update()
    {
        switch(volumeType)
        {
            case VolumeType.MUSIC:
                slider.value = AudioManager.Instance.musicVolume;
                break;
            case VolumeType.SFX:
                slider.value = AudioManager.Instance.sfxVolume;
                break;
            default:
                Debug.LogWarning("Volume type not supported: " + volumeType);
                break;
        }
    }

    public void OnSliderValueChanged()
    {
        switch (volumeType)
        {
            case VolumeType.MUSIC:
                AudioManager.Instance.musicVolume = slider.value;
                break;
            case VolumeType.SFX:
                AudioManager.Instance.sfxVolume = slider.value;
                break;
            default:
                Debug.LogWarning("Volume type not supported: " + volumeType);
                break;
        }
    }
}
