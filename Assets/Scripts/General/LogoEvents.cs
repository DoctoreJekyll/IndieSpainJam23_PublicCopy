using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoEvents : MonoBehaviour
{
    [Header("[References]")]
    [SerializeField] private AudioSource audiosource;

    [Header("[Sounds]")]
    [SerializeField] private AudioClip headsetSFX;


    public void Play_headsetSFX()
    {
        audiosource.PlayOneShot(headsetSFX);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

}
