using System;
using Core;
using UnityEngine;

namespace Player
{
    public class SimpleMovement : MonoBehaviour
    {
        private Vector2 movement;
        
        [Header("Components")]
        [SerializeField] private Rigidbody2D rb2d;
        [SerializeField] private Animator dayAnim;
        [SerializeField] private GameObject dayPlayer;
        [SerializeField] private Animator nigthAnim;
        [SerializeField] private GameObject nigthPlayer;
        
        [Header("Values")]
        public float speed;
        public float normalSpeed;
        [SerializeField] private float runAccelAmount;
        [SerializeField] private float runDeccelAmount;
        [SerializeField] private bool isDay;

        [HideInInspector]
        public Vector2 faceDirection;

        private void Start()
        {
            normalSpeed = speed;
        }

        // Update is called once per frame
        void Update()
        {
            if (IsOnGameplay())
            {
                PlayerInputsValues();
                CheckFaceDirection();
            }
            
            PlayerAnimationController();
        }

        private void FixedUpdate()
        {
            if (IsOnGameplay())
            {
                CanMove();
            }
            else
            {
                rb2d.velocity = Vector2.zero;
                movement = Vector2.zero;
            }

        }
        
        private bool IsOnGameplay()
        {
            return GameStateController.Instance.gameState == GameStateController.GameState.Gameplay;
        }

        private void PlayerInputsValues()
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }

        private void CanMove()
        {
            PlayerMoveImprove();
        }

        private void PlayerMoveImprove()
        {
            Vector2 rate = new Vector2(SpeedDelta().x * AccelerationRate().x, SpeedDelta().y * AccelerationRate().y);
            rb2d.AddForce(rate, ForceMode2D.Force);
        }

        private Vector2 TargetSpeed()
        {
            Vector2 targetSpeed = new Vector2(movement.x, movement.y).normalized * speed;
            
            return targetSpeed;
        }

        private Vector2 AccelerationRate()
        {
            Vector2 accelRate = new Vector2((Mathf.Abs(TargetSpeed().x) > 0.01f) ? runAccelAmount : runDeccelAmount,
                (Mathf.Abs(TargetSpeed().y) > 0.01f) ? runAccelAmount : runDeccelAmount);
            
            return accelRate;
        }

        private Vector2 SpeedDelta()
        {
            Vector2 sDelta = new Vector2(TargetSpeed().x - rb2d.velocity.x, TargetSpeed().y - rb2d.velocity.y);
            return sDelta;
        }

        private void CheckFaceDirection()
        {
            if (movement == Vector2.zero) return;
            
            faceDirection.x = movement.x;
            faceDirection.y = movement.y;

        }

        private void PlayerAnimation(Animator animator)
        {
            if (movement.magnitude != 0)
            {
                animator.SetFloat("Horizontal", movement.x);
                animator.SetFloat("Vertical", movement.y);
                animator.Play("Movement");
            }
            else
            {
                animator.Play("IdleBlend");
            }
        }

        private void SpritePlayerOn(GameObject spriteOn, GameObject spriteOff)
        {
            spriteOn.SetActive(true);
            spriteOff.SetActive(false);
        }

        private void PlayerAnimationController()
        {
            if (isDay)
            {
                PlayerAnimation(dayAnim);
                SpritePlayerOn(dayPlayer, nigthPlayer);
            }
            else
            {
                PlayerAnimation(nigthAnim);
                SpritePlayerOn(nigthPlayer, dayPlayer);
            }
        }

        public void ChangePlayerSprite()
        {
            isDay =! isDay;
        }
        
    }
}
