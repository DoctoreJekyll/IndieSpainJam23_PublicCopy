using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_CirculoRojo : MonoBehaviour
{
    public Color newColor;

    public void SetRedColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = newColor;
    }
}
