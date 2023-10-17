using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_EndingCredits : MonoBehaviour
{
    [Header("[References]")]
    [SerializeField] private AudioSource audiosourceMusica;
    [SerializeField] private AudioSource screamerAudioSource;
    [SerializeField] private AudioSource thunderAudioSource;
    [SerializeField] private AudioSource compañaAudiosource;
    [SerializeField] private Animator endingAnimator;
    [SerializeField] private GameObject endingPanel;

    [Header("[Sounds]")]
    [SerializeField] private AudioClip endingMusic;
    [SerializeField] private AudioClip thunderSFX;
    [SerializeField] private AudioClip screamerSFX;


    public void Play_Ending()
    {
        compañaAudiosource.Stop();
        endingPanel.SetActive(true);
        endingAnimator.Play("ENDING");
    }

    public void Play_EndingMusic()
    {
        audiosourceMusica.PlayOneShot(endingMusic);
    }

    public void Play_ScreamerSFX()
    {
        screamerAudioSource.PlayOneShot(screamerSFX);
        thunderAudioSource.PlayOneShot(thunderSFX);
    }

    public void Load_MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

}
