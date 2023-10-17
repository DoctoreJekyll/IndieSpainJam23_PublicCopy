using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialog : MonoBehaviour
{
    [Header("[Configuration]")]
    [SerializeField] private List<DialogScriptable> dialogList;


    public void ShowDialog()
    {
        UI_DialogPanel.instance.onEndDialog += OnEndDialog;

        Core.GameStateController.Instance.ChangeGameStateTo(Core.GameStateController.GameState.Pause);
        UI_DialogPanel.instance.ShowDialog(dialogList);
    }

    private void OnEndDialog()
    {
        UI_DialogPanel.instance.onEndDialog -= OnEndDialog;
        Core.GameStateController.Instance.ChangeGameStateTo(Core.GameStateController.GameState.Gameplay);
    }
}
