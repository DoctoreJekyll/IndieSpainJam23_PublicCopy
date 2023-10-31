using System;
using System.Collections;
using GameEvents;
using Player;
using UnityEngine;

namespace Core
{
    public class CruceiroActive : MonoBehaviour
    {
        
        [SerializeField] private GameEvent cruceiroEvent;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                PlayerDropBread.Instance.gameObject.GetComponent<Player.PlayerDead>().SetLastCruceiro(gameObject);
                cruceiroEvent.Raise();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                cruceiroEvent.Raise();
            }
        }
        
    }
}
