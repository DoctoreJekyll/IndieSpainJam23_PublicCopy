using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events_Level4 : MonoBehaviour
{
    public static Events_Level4 instance;

    [Header("[References]")]
    [SerializeField] private UI_EndingCredits creditsCanvas;
    [SerializeField] private MazeManager mazeManager;

    [Header("[Configuration]")]
    [SerializeField] private List<DialogScriptable> levelIntroDialog;
    [SerializeField] private List<DialogScriptable> santaCompañaDialog;

    private void Awake()
    {
        CreateSingleton();
    }
    private void CreateSingleton()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        Play_LevelIntro();
    }

    private void Play_LevelIntro()
    {
        Core.GameStateController.Instance.ChangeGameStateTo(Core.GameStateController.GameState.Pause);
        StartCoroutine(Coroutine_LevelIntro());

        IEnumerator Coroutine_LevelIntro()
        {
            UI_FadeCanvas.instance.Play_FadeOut();
            yield return new WaitForSeconds(2);

            UI_DialogPanel.instance.onEndDialog += OnEndDialog;
            UI_DialogPanel.instance.ShowDialog(levelIntroDialog);
        }
    }

    public void Play_Ending()
    {
        Core.GameStateController.Instance.ChangeGameStateTo(Core.GameStateController.GameState.Pause);
        creditsCanvas.Play_Ending();
    }

    private void OnEndDialog()
    {
        UI_DialogPanel.instance.onEndDialog -= OnEndDialog;
        Core.GameStateController.Instance.ChangeGameStateTo(Core.GameStateController.GameState.Gameplay);
    }

}
