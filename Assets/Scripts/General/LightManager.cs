using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightManager : MonoBehaviour
{
    [Header("[References]")]
    [SerializeField] private Light2D globalLight;
    [SerializeField] private GameObject fog;
    [SerializeField] private GameObject playerLight;

    [Header("[Configuration]")]
    [SerializeField] private float lightFadeSpeed;
    [SerializeField] private Color initialColor;
    [SerializeField] private Color[] dayColors;

    [Header("[Values]")]
    [SerializeField] private int currentStep;
    [SerializeField] private Color currentColor;


    private void Awake()
    {
        ResetLight();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
            Darken();

        if(currentColor != dayColors[currentStep])
        {
            currentColor = Color.Lerp(currentColor, dayColors[currentStep], Time.deltaTime * lightFadeSpeed);
            globalLight.color = currentColor;

            if (currentStep == dayColors.Length - 1)
                ActivatePlayerLight();
        }

        if(currentStep == dayColors.Length - 1)
        {
            globalLight.intensity -= Time.deltaTime * lightFadeSpeed / 4;
        }
    }

    public void Darken()
    {
        if(currentStep < dayColors.Length -1)
            currentStep++;
    }

    public void ActivatePlayerLight()
    {
        playerLight.SetActive(true);
        //fog.SetActive(true);
    }

    private void ResetLight()
    {
        currentStep = 0;
        globalLight.color = dayColors[0];
        currentColor = globalLight.color;
    }

}
