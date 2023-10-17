using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

namespace Core
{
    public class FinishMapItem : MonoBehaviour
    {
        [Header("[References]")]
        [SerializeField] private MazeManager mazeManager;

        [Header("[Configuration]")]
        [SerializeField] private string sceneName;
        [SerializeField] private List<DialogScriptable> exitDialog;
        

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
                OnContact();
        }

        private void OnContact()
        {
            if(mazeManager.plantsObtained >= 4)
            {
                FinishLevel();
            }
            else
            {
                UI_DialogPanel.instance.onEndDialog += OnEndExitDialog;
                UI_DialogPanel.instance.ShowDialog(exitDialog);
            }
        }


        private void FinishLevel()
        {
            StaticData.gamePhase++;
            GameStateController.Instance.ChangeGameStateTo(GameStateController.GameState.Pause);
            StartCoroutine(Coroutine_FinishLevel());

            IEnumerator Coroutine_FinishLevel()
            {
                UI_FadeCanvas.instance.Play_FadeIn();
                yield return new WaitForSeconds(2);

                SceneManager.LoadScene(sceneName);
            }
        }

        private void OnEndExitDialog()
        {
            UI_DialogPanel.instance.onEndDialog -= OnEndExitDialog;
            GameStateController.Instance.ChangeGameStateTo(GameStateController.GameState.Gameplay);
        }

    }
}
