using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLastPlant : MonoBehaviour
{
    [Header("[References]")]
    [SerializeField] private GameObject obstacles;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ActivateObstacles();
        }
    }

    private void ActivateObstacles()
    {
        obstacles.SetActive(true);
    }
}
