using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_ShowDialog : MonoBehaviour
{
    public List<DialogScriptable> dialogList; 

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            UI_DialogPanel.instance.ShowDialog(dialogList);
        }
    }
}
