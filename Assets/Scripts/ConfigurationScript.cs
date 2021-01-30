using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ConfigurationScript : MonoBehaviour
{
    public AudioMixer mainMixer;
    public Slider volumeSlider;
    public Slider effectsSlider;

    void Start ()
    {
        setInitialValues();
    }

    private void setInitialValues()
    {
        mainMixer.SetFloat("MainVolume", 0.0f);
        mainMixer.SetFloat("EffectsVolume", 0.0f);
        effectsSlider.value = 0;
        volumeSlider.value = 0;
    }

    public void SetVolume (float volume)
    {
        mainMixer.SetFloat("MainVolume", volume);
    }
    public void SetEffects (float effects)
    {
        mainMixer.SetFloat("EffectsVolume", effects);
    }
}
