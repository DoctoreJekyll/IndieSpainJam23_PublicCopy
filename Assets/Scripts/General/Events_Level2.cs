using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events_Level2 : MonoBehaviour
{
    [Header("[Configuration]")]
    [SerializeField] private List<DialogScriptable> levelIntroDialog;


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

    private void OnEndDialog()
    {
        UI_DialogPanel.instance.onEndDialog -= OnEndDialog;
        Core.GameStateController.Instance.ChangeGameStateTo(Core.GameStateController.GameState.Gameplay);
    }



}
