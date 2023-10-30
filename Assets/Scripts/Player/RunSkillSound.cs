using System;
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
            ControlSound();
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
