using UnityEngine;

namespace Player
{
    public class PlayerParticleController : MonoBehaviour
    {
        [SerializeField] private ParticleSystem particle;
        private PlayerRunSkill playerRunSkill;
        
        // Start is called before the first frame update
        void Start()
        {
            //Es buena practica utilizar en casos asi un requiredcomponent?
            playerRunSkill = GetComponent<PlayerRunSkill>();
        }

        // Update is called once per frame
        void Update()
        {
            ParticleSweatController();
        }

        private void ParticleSweatController()
        {
            if (!playerRunSkill.CanSprint)
            {
                particle.Play();
            }
            else
            {
                particle.Stop();
            }
        }
    }
}
