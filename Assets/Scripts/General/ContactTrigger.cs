using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEvents;

public class ContactTrigger : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private GameEvent triggerEvent;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            OnContact();
            Destroy(this.gameObject);
        }
    }

    private void OnContact()
    {
        triggerEvent.Raise();
    }
}
