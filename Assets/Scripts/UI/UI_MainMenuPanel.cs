using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_MainMenuPanel : MonoBehaviour
{
    [Header("[References]")]
    [SerializeField] private AudioSource audiosource;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject creditsPanel;

    [Header("[Sounds]")]
    [SerializeField] private AudioClip enableSFX;
    [SerializeField] private AudioClip disableSFX;


    public void OnClick_Settings()
    {
        audiosource.PlayOneShot(enableSFX);

        settingsPanel.SetActive(true);
        gameObject.SetActive(false);
    }

    public void OnClick_Credits()
    {
        audiosource.PlayOneShot(enableSFX);

        creditsPanel.SetActive(true);
        gameObject.SetActive(false);
    }

    public void OnClick_Exit()
    {
        Application.Quit();
    }

}
