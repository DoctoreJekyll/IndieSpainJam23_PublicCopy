using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EndMazeTrigger : MonoBehaviour
{
    [Header("[References]")]
    [SerializeField] private MazeManager mazeManager;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //mazeManager.OnEndMaze();
            gameObject.SetActive(false);
        }
    }
}
