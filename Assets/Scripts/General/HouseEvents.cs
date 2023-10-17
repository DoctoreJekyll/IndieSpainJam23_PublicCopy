using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseEvents : MonoBehaviour
{
    [Header("[References]")]
    [SerializeField] private GameObject housePhase1;
    [SerializeField] private GameObject housePhase2;
    [SerializeField] private GameObject housePhase3;
    [SerializeField] private GameObject housePhase4;


    private void Awake()
    {
        PlayNextEvent();
    }

    private void PlayNextEvent()
    {
        switch (StaticData.gamePhase)
        {
            case 0:
                housePhase1.SetActive(true);
                break;
            case 1:
                housePhase2.SetActive(true);
                break;
            case 2:
                housePhase3.SetActive(true);
                break;
            case 3:
                housePhase4.SetActive(true);
                break;
        }
    }

}
