using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_CreditsPanel : MonoBehaviour
{
    [Header("[References]")]
    [SerializeField] private AudioSource audiosource;
    [SerializeField] private GameObject mainMenuPanel;

    [Header("[Sounds]")]
    [SerializeField] private AudioClip disableSFX;

    public void OnClick_Back()
    {
        audiosource.PlayOneShot(disableSFX);

        mainMenuPanel.SetActive(true);
        gameObject.SetActive(false);
    }
}
