using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using GameEvents;
using NavMeshPlus.Components;
using System;
using Cinemachine;

public class MazeManager : MonoBehaviour
{
    public Action OnPlantTaken;

    [Header("[References]")]
    [SerializeField] private CinemachineConfiner cameraConfiner;
    [SerializeField] private PolygonCollider2D levelConfiner;
    [SerializeField] private NavMeshSurface navMeshSurface;
    [SerializeField] private LightManager lightManager;
    [SerializeField] private GameObject initialPlayerPosition;
    [SerializeField] private GameObject dayTime;
    [SerializeField] private GameObject nightTime;
    [SerializeField] private GameObject houseTeleport;

    [Header("[Configuration]")]
    [SerializeField] private int plantsNeeded;

    [Header("[Events]")]
    [SerializeField] private GameEvent spawnEnemy;
    [SerializeField] private GameEvent pjSpriteEvent;

    [Header("[Values]")]
    [SerializeField] public int plantsObtained;


    private void Start()
    {
        //Player_DropBread.instance.RestoreBreadAmount();
        Player_DropBread.instance.gameObject.transform.position = initialPlayerPosition.transform.position;
        cameraConfiner.m_BoundingShape2D = levelConfiner;
        navMeshSurface.BuildNavMesh();
    }

    public void OnPlantObtained()
    {
        plantsObtained++;
        lightManager.Darken();

        if (OnPlantTaken != null)
            OnPlantTaken.Invoke();

        if(plantsObtained == plantsNeeded -1)
        {
            pjSpriteEvent.Raise();
            dayTime.SetActive(false);
            nightTime.SetActive(true);
            spawnEnemy.Raise();
        }

        if (plantsObtained >= plantsNeeded)
            houseTeleport.SetActive(true);
    }


}
