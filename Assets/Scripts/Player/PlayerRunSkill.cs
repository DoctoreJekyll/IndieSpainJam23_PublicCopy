using System;
using UnityEngine;

namespace Player
{
    public class PlayerRunSkill : MonoBehaviour
    {

        [SerializeField] private SimpleMovement playerMovement;
        [SerializeField] private float runSpeed;

        [Header("Particle")] [SerializeField] 
        private ParticleSystem sweatParticle;
        
        [Header("Components")] 
        [SerializeField] private Animator dayAnimator;
        [SerializeField] private Animator nightAnimator;

        private float timePlayerCanSprint;
        private float TimePlayerCanSprint
        {
            get => timePlayerCanSprint;
            set => timePlayerCanSprint = Mathf.Max(value, 0);
        }
        [SerializeField] private float sprintCooldown;

        public bool CanSprint { get; private set; }
        public bool isOnMug;
        
        private void Start()
        {
            CanSprint = true;
        }

        private void Update()
        {
            SprintSkill();

            if (TimePlayerCanSprint >= sprintCooldown)
            {
                CanSprint = false;
                sweatParticle.Play();
                
            }
            else if (TimePlayerCanSprint <= 0)
            {
                TimePlayerCanSprint = 0;
                CanSprint = true;
                sweatParticle.Stop();
            }
        }

        private void SprintSkill()
        {
            if (Input.GetKey(KeyCode.LeftShift) && TimePlayerCanSprint < sprintCooldown)
            {
                if (CanSprint)
                {
                    ChangeAnimationVelocity(2f);
                    TimePlayerCanSprint += Time.deltaTime;

                    if (isOnMug)
                        playerMovement.speed = runSpeed / 2;
                    else
                        playerMovement.speed = runSpeed;
                }

            }
            else//perdón
            {
                if (!isOnMug)
                {
                    ChangeAnimationVelocity( 1f);
                    playerMovement.speed = playerMovement.normalSpeed;
                    TimePlayerCanSprint -= Time.deltaTime;
                }
                else
                {
                    playerMovement.speed = 0.5f;
                    TimePlayerCanSprint -= Time.deltaTime;
                }
 
            }
        }
        
        private void ChangeAnimationVelocity(float newSpeed)
        {
            dayAnimator.speed = newSpeed;
            nightAnimator.speed = newSpeed;
        }
    }
}
