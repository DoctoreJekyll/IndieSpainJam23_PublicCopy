using System.Collections;
using System.Collections.Generic;
using GameEvents;
using UnityEngine;

public class Test_TriggerColorRed : MonoBehaviour
{
    public GameEvent gameEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameEvent.Raise();
        }
    }
}
