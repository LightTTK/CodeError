using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider MasterSlider;
    [SerializeField] private Slider MusicSlider;
    [SerializeField] private Slider SfxSlider;
    [SerializeField] private Slider AmbientSlider;
    private void Start()
    {
        if (PlayerPrefs.HasKey("MasterVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMasterVolume();
        }
        
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
        }
        
        if (PlayerPrefs.HasKey("SfxVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetSfxVolume();
        }
        
        if (PlayerPrefs.HasKey("AmbientVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetAmbientVolume();
        }
    }
    public void SetMasterVolume()
    {
        float volume = MasterSlider.value;
        audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MasterVolume", volume);
        
    }
    
    public void SetMusicVolume()
    {
        float volume = MusicSlider.value;
        audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MusicVolume", volume);
        
    }
    
    public void SetSfxVolume()
    {
        float volume = SfxSlider.value;
        audioMixer.SetFloat("SoundEffects", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SfxVolume", volume);
        
    }
    
    public void SetAmbientVolume()
    {
        float volume = AmbientSlider.value;
        audioMixer.SetFloat("Ambient", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("AmbientVolume", volume);
        
    }

    private void LoadVolume()
    {
        MasterSlider.value = PlayerPrefs.GetFloat("MasterVolume", 0);
        MusicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0);
        SfxSlider.value = PlayerPrefs.GetFloat("SfxVolume", 0);
        AmbientSlider.value = PlayerPrefs.GetFloat("AmbientVolume", 0);
        
        
        
        SetMasterVolume();
        SetMusicVolume();
        SetSfxVolume();
        SetAmbientVolume();
    }

}
