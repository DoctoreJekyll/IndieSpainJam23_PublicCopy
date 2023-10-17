using System;
using Core;
using UnityEngine;

namespace UI
{
    public class PausePanelActive : MonoBehaviour
    {
        [SerializeField] private GameObject pausePanel;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && GameStateController.Instance.gameState == GameStateController.GameState.Gameplay)
            {
                pausePanel.SetActive(true);
            }
        }
    }
}
