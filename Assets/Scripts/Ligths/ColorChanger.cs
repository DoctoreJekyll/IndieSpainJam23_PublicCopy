using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ColorChanger : MonoBehaviour
{
    public Light2D luz;
    public Color[] colores;
    Color currentColor;
    public float step;
    
    
    // Start is called before the first frame update
    void Start()
    {
        step = 1 / colores.Length;
        luz.color = colores[0];
        currentColor = luz.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.K))
        {
            currentColor = Color.Lerp(currentColor, colores[1], step);
            luz.color = currentColor;
        }
    }
}
