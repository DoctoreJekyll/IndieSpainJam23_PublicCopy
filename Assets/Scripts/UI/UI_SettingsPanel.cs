using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UI_SettingsPanel : MonoBehaviour
{
    [Header("[References]")]
    [SerializeField] private AudioSource audiosource;
    [SerializeField] private AudioMixer audiomixer;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private GameObject mainMenuPanel;

    [Header("[Sounds]")]
    [SerializeField] private AudioClip disableSFX;


    private void OnEnable()
    {
        audiomixer.GetFloat("Master", out float currentVolume);
        volumeSlider.value = Mathf.Pow(10, currentVolume / 20);

        volumeSlider.onValueChanged.AddListener(SetMusicVolume);
    }

    private void OnDisable()
    {
        volumeSlider.onValueChanged.RemoveListener(SetMusicVolume);
    }

    private void SetMusicVolume(float sliderValue)
    {
        audiomixer.SetFloat("Master", Mathf.Log10(sliderValue) * 20);

        if(sliderValue <= 0)
            audiomixer.SetFloat("Master", -80);
    }

    public void OnClick_Save()
    {
        audiosource.PlayOneShot(disableSFX);

        mainMenuPanel.SetActive(true);
        gameObject.SetActive(false);
    }
}
