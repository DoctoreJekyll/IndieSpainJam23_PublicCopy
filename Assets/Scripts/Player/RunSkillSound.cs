using System;
using Core;
using UnityEngine;

namespace Player
{
    public class RunSkillSound : MonoBehaviour
    {

        private PlayerRunSkill playerRunSkill;
        private AudioSource audioS;
        private bool soundOn;

        private void Start()
        {
            playerRunSkill = GetComponent<PlayerRunSkill>();
            audioS = GetComponent<AudioSource>();
        }

        private void Update()
        {
            if(IsOnGameplay())
            {
                ControlSound();
            }
        }

        //Preguntar si es mejor hacer esto aqui o directamente en el GameStateController
        private bool IsOnGameplay()
        {
            return GameStateController.Instance.gameState == GameStateController.GameState.Gameplay;
        }

        private void ControlSound()
        {
            if (!playerRunSkill.CanSprint)
            {
                if (soundOn)
                {
                    soundOn = false;
                    audioS.Play();
                }
            }
            else
            {
                audioS.Stop();
                soundOn = true;
            }
        }
        
        
        
        
    }
}
