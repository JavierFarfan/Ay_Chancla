using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class MenuSetting : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    public Slider musicSlider;
    public Slider sfxSlider;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        musicSlider.onValueChanged.AddListener(ChangeSoundsMusic);
        sfxSlider.onValueChanged.AddListener(ChangeSoundsSFX); 
    }
    private void Start()
    {
        Charge();       
    }
    public void ChangeSoundsMusic(float sound)
    {
        audioMixer.SetFloat("VolumenMusic", Mathf.Log10(sound) * 20);
        PlayerPrefs.SetFloat("VolumenMusic", musicSlider.value);
    }
    public void ChangeSoundsSFX(float sound)
    {
        audioMixer.SetFloat("VolumenSFX", Mathf.Log10(sound) * 20);
        PlayerPrefs.SetFloat("VolumenSFX", sfxSlider.value);  
    }
    private void Charge()
    {
        musicSlider.value = PlayerPrefs.GetFloat("VolumenMusic", 1f);
        sfxSlider.value = PlayerPrefs.GetFloat("VolumenSFX", 1f);
        ChangeSoundsMusic(musicSlider.value);
        ChangeSoundsSFX(sfxSlider.value);
    }

}
