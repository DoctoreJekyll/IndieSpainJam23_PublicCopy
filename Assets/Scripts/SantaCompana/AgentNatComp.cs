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
            if (GameStateController.Instance.IsOnGameplay())
            {
                agent.isStopped = false;
                AgentFollow(EnemyDestination());
            }
            else
            {
                agent.isStopped = true;
            }
            
            ChangeAgentSpeed();
            EnemyAgentDirectionFace();
        }

        private void ChangeAgentSpeed()
        {
            if (!followPlayer)
            {
                agent.speed = newDestinationSpeed;
            }
            else
            {
                var distance = Distance();
                agent.speed = distance >= distanceMinPlayer ? outRangePlayerSpeed : normalSpeed;
            }
        }

        private float Distance()
        {
            float distance = Vector3.Distance(this.gameObject.transform.position, player.transform.position);
            return distance;
        }

        private void AgentFollow(Transform target)
        {
            agent.SetDestination(target.position);
        }

        private Transform EnemyDestination()
        {
            if (followPlayer)
            {
                return player.transform;
            }
            
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

        private void EnemyAgentDirectionFace()
        {
            var currentPos = CurrentPos();
            var moveDirection = MoveDirection(currentPos);
            EnemyAnim(moveDirection);
            lastPos = currentPos;
        }

        private Vector2 MoveDirection(Vector2 currentPos)
        {
            Vector2 moveDirection = currentPos - lastPos;
            return moveDirection;
        }

        private Vector2 CurrentPos()
        {
            Vector2 currentPos = transform.position;
            return currentPos;
        }

        private void EnemyAnim(Vector2 moveDirection)
        {
            animator.SetFloat("Horizontal", moveDirection.x);
            animator.SetFloat("Vertical", moveDirection.y);
        }
    }
}
