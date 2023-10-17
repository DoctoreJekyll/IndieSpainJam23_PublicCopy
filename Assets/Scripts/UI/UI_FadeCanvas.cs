using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_FadeCanvas : MonoBehaviour
{
    public static UI_FadeCanvas instance;

    [Header("[References]")]
    [SerializeField] private Animator fadeAnimator;


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

    private void Start()
    {
        Play_FadeOut();
    }


    public void Play_FadeIn()
    {
        fadeAnimator.Play("FADE IN");
    }

    public void Play_FadeOut()
    {
        fadeAnimator.Play("FADE OUT");
    }

}
