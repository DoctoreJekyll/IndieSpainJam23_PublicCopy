using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuStartEvent : MonoBehaviour
{
    [Header("[References]")]
    [SerializeField] private AudioSource audiosourceMusica;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Animator startAnimator;

    [Header("[Sounds]")]
    [SerializeField] private AudioClip thunderSFX;
    [SerializeField] private AudioClip bellSFX;


    public void Play_StartAnimation()
    {
        startAnimator.Play("START");
    }

    public void Play_ThunderSFX()
    {
        audiosourceMusica.Stop();
        audioSource.PlayOneShot(thunderSFX);
        audioSource.PlayOneShot(bellSFX);
    }

    public void LoadGameplay()
    {
        SceneManager.LoadScene("Gameplay Casa");
    }
}
