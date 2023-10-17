using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Ligths
{
    public class FarolController : MonoBehaviour
    {
        [SerializeField] private Light2D farolLigth;
        
        [Header("Time rate reducing ligth")]
        [Range(0.01f,0.1f)]
        [SerializeField] float reductionRate = 0.1f;

        [Header("Values")]
        [SerializeField] private float intensityValue;
        [SerializeField] private float outerValue;
        [SerializeField] private bool wastingLigth;

        [SerializeField] private bool torchFirstOn;

        [SerializeField] private float initValueIntensity;
        private float initValueOuter;

        private void Start()
        {
            torchFirstOn = false;
            initValueIntensity = farolLigth.intensity;
            initValueOuter = farolLigth.pointLightOuterRadius;

            farolLigth.intensity = 0f;

            StartCoroutine(FirstTorchOn());
        }

        private IEnumerator FirstTorchOn()
        {
            while (farolLigth.intensity < initValueIntensity)
            {
                farolLigth.intensity += 0.01f;
                yield return new WaitForEndOfFrame();
            }

            torchFirstOn = true;
        }
        
        private void Update()
        {

            if (torchFirstOn)
            {
                if (wastingLigth)
                {
                    ChangeIntesityValueReduce();
                    ChangeOuterValueReduce();
                }
                else if (!wastingLigth)
                {
                    ChangeIntesityValueIncrease(100);
                    ChangeOuterValueIncrease(100);
                }
            }
        }
        
        private void ChangeIntesityValueReduce()
        {

            if (farolLigth.intensity > intensityValue)
            {
                farolLigth.intensity -= (reductionRate * Time.deltaTime);
                
                if (farolLigth.intensity < intensityValue)
                {
                    farolLigth.intensity = intensityValue;
                }
            }
        }
        
        private void ChangeOuterValueReduce()
        {
            if (farolLigth.pointLightOuterRadius > outerValue)
            {
                farolLigth.pointLightOuterRadius -= (reductionRate * Time.deltaTime);
                
                if (farolLigth.pointLightOuterRadius < outerValue)
                {
                    farolLigth.pointLightOuterRadius = outerValue;
                }
            }
        }

        private void ChangeIntesityValueIncrease(float aum)
        {
            if (farolLigth.intensity < initValueIntensity)
            {
                farolLigth.intensity += (reductionRate * Time.deltaTime) * aum;
                
                if (farolLigth.intensity > initValueIntensity)
                {
                    farolLigth.intensity = initValueIntensity;
                }
            }
        }
        
        private void ChangeOuterValueIncrease(float aum)
        {
            if (farolLigth.pointLightOuterRadius < initValueOuter)
            {
                farolLigth.pointLightOuterRadius += (reductionRate * Time.deltaTime) * aum;
                
                if (farolLigth.pointLightOuterRadius > initValueOuter)
                {
                    farolLigth.pointLightOuterRadius = initValueOuter;
                }
            }
        }

        public void ChangeBooleanLigthValue()
        {
            wastingLigth = !wastingLigth;
        }

    }
}
