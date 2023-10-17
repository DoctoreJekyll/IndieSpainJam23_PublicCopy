using UnityEngine;

namespace Player
{
    public class Steps : MonoBehaviour
    {

        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip[] stepsClip;

        public void StepSound()
        {
            int randomClip = Random.Range(0, stepsClip.Length);
            audioSource.pitch = Random.Range(0.9f, 1.1f);
            audioSource.PlayOneShot(stepsClip[randomClip]);
        }

    }
}
