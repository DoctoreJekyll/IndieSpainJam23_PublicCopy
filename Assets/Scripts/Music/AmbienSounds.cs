using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

namespace Music
{
    public class AmbienSounds : MonoBehaviour
    {

        [SerializeField] private AudioSource audioSourceDay;
        [SerializeField] private AudioSource audioSourceNigth;

        private void OnEnable()
        {
            StartFadeTest(audioSourceDay, 4f, 0.15f);
        }

        private void OnDisable()
        {
            audioSourceDay.Stop();
        }

        private void StartFadeTest(AudioSource audioS, float duration, float targetVolume)
        {
            audioS.Play();
            float currentTime = 0;
            float start = audioS.volume;
    
            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                audioS.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            }
        }

        private void FadeOutTest(AudioSource audioS, float duration, float targetVolume)
        {
            float currentTime = 0;
            float start = audioS.volume;
    
            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                audioS.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                ChangeMusic();
            }
        }

        public void ChangeMusic()
        {
            FadeOutTest(audioSourceDay, 3f, 0f);
            StartFadeTest(audioSourceNigth, 4f, 0.15f);
        }

        
    }
}
