using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeSelector : MonoBehaviour
{
    [Header("[References]")]
    [SerializeField] private GameObject maze1;
    [SerializeField] private GameObject maze2;
    [SerializeField] private GameObject maze3;
    [SerializeField] private GameObject maze4;

    [Header("[Debug]")]
    [SerializeField] private int setLevel;

    private void Awake()
    {
        if(setLevel != -1)
        {
            switch (setLevel)
            {
                case 0:
                    maze1.SetActive(true);
                    break;
                case 1:
                    maze2.SetActive(true);
                    break;
                case 2:
                    maze3.SetActive(true);
                    break;
                case 3:
                    maze4.SetActive(true);
                    break;
            }
        }
        else
        {
            switch (StaticData.gamePhase)
            {
                case 0:
                    maze1.SetActive(true);
                    break;
                case 1:
                    maze2.SetActive(true);
                    break;
                case 2:
                    maze3.SetActive(true);
                    break;
                case 3:
                    maze4.SetActive(true);
                    break;
            }
        }

        
    }
}
