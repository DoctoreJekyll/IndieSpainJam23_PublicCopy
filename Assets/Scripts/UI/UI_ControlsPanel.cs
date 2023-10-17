using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ControlsPanel : MonoBehaviour
{
    public static UI_ControlsPanel instance;

    [Header("[References]")]
    [SerializeField] private Animator controlsAnimator;

    private void Awake()
    {
        CreateSingleton();
    }
    private void CreateSingleton()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }


    public void Show_BasicControls()
    {
        controlsAnimator.Play("SHOW BASICS");
    }

    public void Show_AdvancedControls()
    {
        controlsAnimator.Play("SHOW ADVANCED");
    }

    public void HideAll()
    {
        controlsAnimator.Play("HIDE ALL");
    }

}
