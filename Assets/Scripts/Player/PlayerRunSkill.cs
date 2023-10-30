using System;
using UnityEngine;

namespace Player
{
    public class PlayerRunSkill : MonoBehaviour
    {
        [Header("Values")]
        [SerializeField] private float runSpeed;
        [SerializeField] private float sprintCooldown;
        public bool CanSprint { get; private set; }
        public bool isOnMug;

        [Header("Components")] 
        [SerializeField] private SimpleMovement playerMovement;
        [SerializeField] private Animator dayAnimator;
        [SerializeField] private Animator nightAnimator;

        private float timePlayerCanSprint;
        private float TimePlayerCanSprint
        {
            get => timePlayerCanSprint;
            set => timePlayerCanSprint = Mathf.Max(value, 0);
        }

        private void Start()
        {
            CanSprint = true;
        }

        private void Update()
        {
            SprintSkillController();
            SprintSkillTimeControl();
        }

        private void SprintSkillController()
        {
            if (Input.GetKey(KeyCode.LeftShift) && CanSprint)
            {
                ChangeAnimationVelocity(2f);
                AddTimeToPlayerSprint(1f);

                if (isOnMug)
                    SetPlayerMoveSpeed(runSpeed / 2);
                else
                    SetPlayerMoveSpeed(runSpeed);
            }
            else
            {
                if (!isOnMug)
                {
                    ChangeAnimationVelocity( 1f);
                    SetPlayerMoveSpeed(playerMovement.normalSpeed);
                    AddTimeToPlayerSprint(-1f);
                }
                else
                {
                    SetPlayerMoveSpeed(0.5f);
                    AddTimeToPlayerSprint(-1f);
                }
            }
        }

        private void SprintSkillTimeControl()
        {
            if (TimePlayerCanSprint >= sprintCooldown)
            {
                CanSprint = false;

            }
            else if (TimePlayerCanSprint <= 0)
            {
                TimePlayerCanSprint = 0;
                CanSprint = true;
            }
        }

        private void SetPlayerMoveSpeed(float newPlayerSpeed)
        {
            playerMovement.speed = newPlayerSpeed;
        }

        private void AddTimeToPlayerSprint(float value)
        {
            TimePlayerCanSprint += Time.deltaTime * value;
        }
        
        private void ChangeAnimationVelocity(float newSpeed)
        {
            dayAnimator.speed = newSpeed;
            nightAnimator.speed = newSpeed;
        }
    }
}
