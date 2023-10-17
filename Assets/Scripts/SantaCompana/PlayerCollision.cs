using System;
using Core;
using GameEvents;
using UnityEngine;

namespace SantaCompana
{
    public class PlayerCollision : MonoBehaviour
    {

        [SerializeField] private GameEvent deadEvent;
        
        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                deadEvent.Raise();
            }
        }
    }
}
