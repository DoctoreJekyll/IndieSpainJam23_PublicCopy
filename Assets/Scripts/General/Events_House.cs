using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events_House : MonoBehaviour
{
    void Start()
    {
        if(StaticData.gamePhase == 0)
        {
            Invoke(nameof(Show_BasicControls), 2);
        }    
    }

    private void Show_BasicControls()
    {
        UI_ControlsPanel.instance.Show_BasicControls();
    }
}
