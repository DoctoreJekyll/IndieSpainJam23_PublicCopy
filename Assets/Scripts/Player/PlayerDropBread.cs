using Core;
using UnityEngine;

namespace Player
{
    public class PlayerDropBread : MonoBehaviour
    {
        public static PlayerDropBread Instance;

        [Header("[References]")]
        [SerializeField] private GameObject breadPrefab;

        [Header("[Configuration]")]
        [SerializeField] private float timeColdown;

        [Header("[Values]")]
        [SerializeField] private float currentTime;

        private bool canDropBread;


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

        private void Start()
        {
            currentTime = 0f;
            canDropBread = true;
        }

        private void Update()
        {
            if (!canDropBread)
            {
                currentTime += Time.deltaTime;
                if (DropBreadCooldownCheck())
                {
                    ResetBread();
                }
            }
        
            if(Input.GetKeyDown(KeyCode.E) && IsOnGameplay())
            {
                if (canDropBread)
                {
                    InstantiateBread();
                }
            }
        }

        private void InstantiateBread()
        {
            Instantiate(breadPrefab, gameObject.transform.position, Quaternion.identity);
            canDropBread = false;
        }

        private void ResetBread()
        {
            canDropBread = true;
            currentTime = 0;
        }

        private bool DropBreadCooldownCheck()
        {
            return currentTime > timeColdown;
        }
        
        //He vuelto a crear este metodo, me interesa tenerlos en los scripts para legibilidad o crear este metodo dentro del singleton
        private bool IsOnGameplay()
        {
            return GameStateController.Instance.gameState == GameStateController.GameState.Gameplay;
        }

    }
}
