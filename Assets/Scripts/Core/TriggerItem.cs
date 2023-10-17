using System;
using GameEvents;
using UnityEngine;

namespace Core
{
    public class TriggerItem : MonoBehaviour
    {



        [Header("Obj Exit")] 
        [SerializeField] private GameObject exitObj;

        [Header("Events")] 
        [SerializeField] private GameEvent onTriggerEnemy;
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                PlayerTakeObject();
                Destroy(this.gameObject);
            }
        }

        private void PlayerTakeObject()
        {
            onTriggerEnemy.Raise();
            //Activamos el objeto que sirve para escapar del laberinto
            exitObj.SetActive(true);
        }
        
    }
}
