using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogController : MonoBehaviour
{

    [SerializeField] private Renderer fogMaterial;

    [SerializeField] private float initValue;
    [SerializeField] private float nigthValue;


    private void OnEnable()
    {
        fogMaterial = GetComponent<Renderer>();
        fogMaterial.sharedMaterial.SetFloat("_Fog_transparency", initValue);
    }

    public void StartCorroutineFog()
    {
        StartCoroutine(FogCorroutine());
    }

    IEnumerator FogCorroutine()
    {
        while (nigthValue < initValue)
        {
            fogMaterial.sharedMaterial.SetFloat("_Fog_transparency", initValue -= 0.01f);
            yield return new WaitForSeconds(0.1f);
        }
    }

}
