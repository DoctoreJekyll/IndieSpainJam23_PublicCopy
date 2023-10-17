using Core;
using Player;
using UnityEngine;
using UnityEngine.AI;

namespace SantaCompana
{
    public class AgentNatComp : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private Transform player;
        [SerializeField] private GameObject[] newDestinationsArray;
        [SerializeField] private Animator animator;
        private GameObject newDestinationNav;

        [Header("Values")]
        [SerializeField] private float distanceMinPlayer;
        [SerializeField] private float normalSpeed;
        [SerializeField] private float newDestinationSpeed;
        [SerializeField] private float outRangePlayerSpeed;

        [Header("Player follow check")]
        [SerializeField] private bool followPlayer;

        private Vector2 lastPos;

        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            player = FindObjectOfType<SimpleMovement>().gameObject.transform;
            newDestinationsArray = GameObject.FindGameObjectsWithTag("Destination");
            
            agent.updateRotation = false;
            agent.updateUpAxis = false;

            lastPos = transform.position;

            if (StaticData.gamePhase != 0)
            {
                normalSpeed = 1.85f;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (GameStateController.Instance.gameState == GameStateController.GameState.Gameplay)
            {
                agent.isStopped = false;
                AgentFollow(EnemyDestination());
                //AgentDistance(player);
            }
            else
            {
                agent.isStopped = true;
            }
            
            ChangeAgentSpeed();
            TestAgentDirectionPos();
        }

        private void ChangeAgentSpeed()
        {
            if (!followPlayer)
            {
                agent.speed = newDestinationSpeed;
            }
            else
            {
                float distance = Vector3.Distance(this.gameObject.transform.position, player.transform.position);
                agent.speed = distance >= distanceMinPlayer ? outRangePlayerSpeed : normalSpeed;
            }
        }

        private void AgentFollow(Transform target)
        {
            agent.SetDestination(target.position);
        }

        //private void AgentDistance(Transform target)
        //{
        //    float distance = Vector3.Distance(this.gameObject.transform.position, target.transform.position);

        //    agent.speed = distance >= distanceMinPlayer ? outRangePlayerSpeed : normalSpeed;
        //}

        private Transform EnemyDestination()
        {
            if (followPlayer)
            {
                return player.transform;
            }

            //TODO Quizas meter un random de dos o tres destinos
            return newDestinationNav.transform;
        }

        public void SetANewDestination()
        {
            newDestinationNav = newDestinationsArray[Random.Range(0, newDestinationsArray.Length)];
        }

        public void ChangeFollowBoolValue()
        {
            followPlayer =! followPlayer;
        }
        
        private Vector2 CheckAgentDirection()
        {
            Vector2 direction = (EnemyDestination().position - transform.position).normalized;
            return direction;
        }

        private void TestAgentDirectionPos()
        {
            Vector2 currentPos = transform.position;
            Vector2 moveDirection = currentPos - lastPos;
            EnemyAnim(moveDirection);
            lastPos = currentPos;
        }

        private void EnemyAnim(Vector2 moveDirection)
        {
            animator.SetFloat("Horizontal", moveDirection.x);
            animator.SetFloat("Vertical", moveDirection.y);
            //animator.SetFloat("Speed", CheckAgentDirection().sqrMagnitude);
        }
    }
}
