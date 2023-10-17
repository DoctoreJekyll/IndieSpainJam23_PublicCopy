using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicinalPlant : MonoBehaviour
{
    [Header("[References]")]
    [SerializeField] private MazeManager mazeManager;
    [SerializeField] private Collider2D coll2D;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject particleObj;

    [Header("[Configuration]")]
    [SerializeField] private List<DialogScriptable> firstPlantDialog;

    [SerializeField] private AudioSource aSource;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            TakePlant();
    }

    private void TakePlant()
    {
        aSource.Play();
        mazeManager.OnPlantObtained();
        coll2D.enabled = false;
        spriteRenderer.enabled = false;
        particleObj.SetActive(false);
    }

}
