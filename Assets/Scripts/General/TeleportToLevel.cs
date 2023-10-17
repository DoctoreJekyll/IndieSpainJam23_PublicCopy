using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportToLevel : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            TeleportPlayer();
    }

    private void TeleportPlayer()
    {
        StartCoroutine(Coroutine_TeleportPlayer());

        IEnumerator Coroutine_TeleportPlayer()
        {
            Core.GameStateController.Instance.ChangeGameStateTo(Core.GameStateController.GameState.Pause);
            UI_FadeCanvas.instance.Play_FadeIn();
            yield return new WaitForSeconds(2);

            SceneManager.LoadScene("Gameplay");
        }
    }
}
