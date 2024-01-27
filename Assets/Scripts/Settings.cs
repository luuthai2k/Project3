using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class Settings : MonoBehaviour
{
    public AudioMixer mixer;

    public Slider masterSlider;
    public Slider sfxSlider;
    public Slider musicSlider;

    protected float MasterVolume;
    protected float SFXVolume;
    protected float MusicVolume;

    protected const float MinVolume = -80f;
    protected const string MasterVolumeFloat = "MasterVolume";
    protected const string SFXVolumeFloat = "SFXVolume";
    protected const string MusicVolumeFloat = "MusicVolume";

    public GameObject ResetedPrefs;

    void Update()
    {
        UpdateUI();
    }

    public void MasterVolChangeValue(float value)
    {
        MasterVolume = MinVolume * (1.0f - value);
        mixer.SetFloat(MasterVolumeFloat, MasterVolume);
    }

    public void SFXVolChangeValue(float value)
    {
        SFXVolume = MinVolume * (1.0f - value);
        mixer.SetFloat(SFXVolumeFloat, SFXVolume);
    }

    public void MusicVolChangeValue(float value)
    {
        MusicVolume = MinVolume * (1.0f - value);
        mixer.SetFloat(MusicVolumeFloat, MusicVolume);
    }

    void UpdateUI()
    {
        mixer.GetFloat(MasterVolumeFloat, out MasterVolume);
        mixer.GetFloat(MusicVolumeFloat, out MusicVolume);
        mixer.GetFloat(SFXVolumeFloat, out SFXVolume);

        masterSlider.value = 1.0f - (MasterVolume / MinVolume);
        musicSlider.value = 1.0f - (MusicVolume / MinVolume);
        sfxSlider.value = 1.0f - (SFXVolume / MinVolume);
    }

    public void ResetPrefs()
    {
        PlayerPrefs.DeleteAll();
        ResetedPrefs.SetActive(true);
    }
}
