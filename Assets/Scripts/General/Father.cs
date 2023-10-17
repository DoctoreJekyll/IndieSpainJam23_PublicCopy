using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Father : MonoBehaviour, IInteractable
{
    [Header("[References]")]
    [SerializeField] private HouseDoor houseDoor;

    [Header("[Configuration]")]
    [SerializeField] private List<DialogScriptable> phase1_Dialog;
    [SerializeField] private List<DialogScriptable> phase2_Dialog;
    [SerializeField] private List<DialogScriptable> phase3_Dialog;
    [SerializeField] private List<DialogScriptable> phase4_Dialog;

    private void Start()
    {
        Debug.Log("La fase del juego actual es:" + StaticData.gamePhase);
    }

    public void Interact()
    {
        UI_DialogPanel.instance.onEndDialog += OnEndDialog;
        Core.GameStateController.Instance.ChangeGameStateTo(Core.GameStateController.GameState.Pause);

        switch (StaticData.gamePhase)
        {
            case 0:
                UI_DialogPanel.instance.ShowDialog(phase1_Dialog);
                break;
            case 1:
                UI_DialogPanel.instance.ShowDialog(phase2_Dialog);
                break;
            case 2:
                UI_DialogPanel.instance.ShowDialog(phase3_Dialog);
                break;
            case 3:
                UI_DialogPanel.instance.ShowDialog(phase4_Dialog);
                break;
        }

        houseDoor.talkedToDad = true;
    }


    private void OnEndDialog()
    {
        UI_DialogPanel.instance.onEndDialog -= OnEndDialog;
        Core.GameStateController.Instance.ChangeGameStateTo(Core.GameStateController.GameState.Gameplay);
        Player_Interactor.instance.EnableInteracting();
    }
}
