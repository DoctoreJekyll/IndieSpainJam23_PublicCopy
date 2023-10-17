using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events_Level1 : MonoBehaviour
{
    [Header("[References]")]
    [SerializeField] private MazeManager mazeManager;

    [Header("[Configuration]")]
    [SerializeField] private List<DialogScriptable> levelIntroDialog;
    [SerializeField] private List<DialogScriptable> firstPlantDialog;
    [SerializeField] private List<DialogScriptable> thirdPlantDialog;

    [Header("[Values]")]
    [SerializeField] private int totalPlants;

    private void Start()
    {
        Play_LevelIntro();
        mazeManager.OnPlantTaken += PlantTaken;
    }

    private void Play_LevelIntro()
    {
        Core.GameStateController.Instance.ChangeGameStateTo(Core.GameStateController.GameState.Pause);
        StartCoroutine(Coroutine_LevelIntro());

        IEnumerator Coroutine_LevelIntro()
        {
            UI_FadeCanvas.instance.Play_FadeOut();
            yield return new WaitForSeconds(2);

            UI_DialogPanel.instance.onEndDialog += OnEndIntroDialog;
            UI_DialogPanel.instance.ShowDialog(levelIntroDialog);
        }
    }

    private void PlantTaken()
    {
        totalPlants++;

        if(totalPlants == 1)
            OnFirstPlantTaken();

        else if(totalPlants == 3)
            OnThirdPlantTaken();
    }

    private void OnFirstPlantTaken()
    {
        UI_DialogPanel.instance.onEndDialog += OnEndDialog;
        UI_DialogPanel.instance.ShowDialog(firstPlantDialog);
    }

    private void OnThirdPlantTaken()
    {
        UI_DialogPanel.instance.onEndDialog += OnEndDialog;
        UI_DialogPanel.instance.ShowDialog(thirdPlantDialog);
        UI_ControlsPanel.instance.HideAll();
    }

    private void OnEndIntroDialog()
    {
        UI_DialogPanel.instance.onEndDialog -= OnEndIntroDialog;
        Core.GameStateController.Instance.ChangeGameStateTo(Core.GameStateController.GameState.Gameplay);
        Invoke(nameof(Show_AdvancedControls), 2);
    }

    private void OnEndDialog()
    {
        UI_DialogPanel.instance.onEndDialog -= OnEndDialog;
        Core.GameStateController.Instance.ChangeGameStateTo(Core.GameStateController.GameState.Gameplay);
    }

    private void Show_AdvancedControls()
    {
        UI_ControlsPanel.instance.Show_AdvancedControls();
    }
}
