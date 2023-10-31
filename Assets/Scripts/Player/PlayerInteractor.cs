using System.Collections;
using Core;
using UnityEngine;

namespace Player
{
    public class PlayerInteractor : MonoBehaviour
    {
        public static PlayerInteractor Instance;

        [Header("[References]")]
        [SerializeField] private SimpleMovement playerMovement;

        [Header("[Configuration]")]
        [SerializeField] private LayerMask interactableLayer;
        [SerializeField] private float rayLenght;
        [SerializeField] private bool interacting;
        
        private GameObject alertObj;


        private void Awake()
        {
            CreateSingleton();
        }
        private void CreateSingleton()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }


        private void Update()
        {
            if(interacting == false)
            {
                if (Input.GetKeyDown(KeyCode.Space) && GameStateController.Instance.IsOnGameplay())
                {
                    CallInteraction();
                }
            }
            ActiveInteractGameObject();
        }
        
        private void ActiveInteractGameObject()
        {
            if (RayCastIsTouchingObj())
            {
                GameObject newAlertObj = RayCastLaunch().transform.GetChild(0).gameObject;
                
                if (!newAlertObj.activeSelf)
                {
                    newAlertObj.SetActive(true);
                    alertObj = newAlertObj;
                }
            }
            else
            {
                if (alertObj != null && alertObj.activeSelf)
                {
                    alertObj.SetActive(false);
                }
            }
        }

        private void CallInteraction()
        {
            if(RayCastIsTouchingObj())
            {
                interacting = true;
                RayCastLaunch().transform.gameObject.GetComponent<IInteractable>().Interact();
            }
        }

        private Vector2 FaceDirection()
        {
            return new Vector2(playerMovement.faceDirection.x, playerMovement.faceDirection.y);
        }

        private RaycastHit2D RayCastLaunch()
        {
            RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, FaceDirection(), rayLenght, interactableLayer);
            return hit;
        }

        private bool RayCastIsTouchingObj()
        {
            return RayCastLaunch().collider != null;
        }

        public void EnableInteracting()
        {
            StartCoroutine(CoroutineEnableInteracting());

            IEnumerator CoroutineEnableInteracting()
            {
                yield return new WaitForSeconds(0.25f);
                interacting = false;
            }
        }
    }
}
