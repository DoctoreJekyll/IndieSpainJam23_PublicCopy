using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEvents;

public class TestEvents : MonoBehaviour
{
    [SerializeField] private GameEvent playerChangeSpriteEvent;
    [SerializeField] private GameEvent changeMusicEvent;
    private void OnEnable()
    {
        playerChangeSpriteEvent.Raise();
        changeMusicEvent.Raise();
    }
}
