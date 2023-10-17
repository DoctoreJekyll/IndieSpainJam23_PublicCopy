using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace General
{
    public class RainController : MonoBehaviour
    {

        [SerializeField] private ParticleSystem rainParticle;
        [SerializeField] private GameObject particleObj;

        private void Update()
        {

            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                particleObj.gameObject.SetActive(false);
                rainParticle.Stop();
            }
            else if (StaticData.gamePhase >= 2 && SceneManager.GetActiveScene().buildIndex != 2)
            {
                particleObj.gameObject.SetActive(true);
                rainParticle.Play();
            }
        }
    }
}
