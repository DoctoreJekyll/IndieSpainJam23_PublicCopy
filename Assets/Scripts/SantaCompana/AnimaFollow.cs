using System;
using UnityEngine;
using UnityEngine.AI;

namespace SantaCompana
{
    public class AnimaFollow : MonoBehaviour
    {

        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private NavMeshAgent destinyAgent;
        [SerializeField] private Transform destination;

        [SerializeField] private Animator animator;
        [SerializeField] private string animName;
        [SerializeField] private string animaFollowTag;

        private void Start()
        {
            agent.updateRotation = false;
            agent.updateUpAxis = false;

            destinyAgent = GameObject.FindGameObjectWithTag("Enemy").GetComponent<NavMeshAgent>();
            destination = GameObject.FindGameObjectWithTag(animaFollowTag).transform;
            
            animator.Play(animName);
        }

        private void Update()
        {
            agent.speed = destinyAgent.speed;
            agent.SetDestination(destination.position);
        }
    }
}
