using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroductionCanvas : MonoBehaviour
{
    [Header("[References]")]
    [SerializeField] private AudioSource audiosource;
    [SerializeField] private Animator introductionAnimator;
    [SerializeField] private GameObject introductionPanel;

    [Header("[Sounds]")]
    [SerializeField] private AudioClip textSFX;


    private void Start()
    {
        Core.GameStateController.Instance.ChangeGameStateTo(Core.GameStateController.GameState.Pause);
        introductionPanel.SetActive(true);

        switch (StaticData.gamePhase)
        {
            case 0:
                introductionAnimator.Play("INTRO 1");
                break;
            case 1:
                introductionAnimator.Play("INTRO 2");
                break;
            case 2:
                introductionAnimator.Play("INTRO 3");
                break;
            case 3:
                introductionAnimator.Play("INTRO 4");
                break;
        }
    }


    public void Play_TextSFX()
    {
        audiosource.PlayOneShot(textSFX);
    }

    public void Disable_IntroductionPanel()
    {
        Core.GameStateController.Instance.ChangeGameStateTo(Core.GameStateController.GameState.Gameplay);
        introductionPanel.SetActive(false);
    }

}
